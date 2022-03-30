using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputControllerPlatform : MonoBehaviour
    {
        public float stepSize = 0.2f;
        public GameObject player = null;
        public GameObject climbArea = null;
        GameModel model = Schedule.GetModel<GameModel>();
        
        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }

        void DialogControl()
        {
            model.player.nextMoveCommand = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                model.dialog.FocusButton(-1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                model.dialog.FocusButton(+1);
            if (Input.GetKeyDown(KeyCode.Space))
                model.dialog.SelectActiveButton();
        }

        void CharacterControl()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GameObject.Find("Character").GetComponent<CharacterController2DPlatform>().JumpInput();
            if (Input.GetKey(KeyCode.A))
            {
                player.GetComponent<CharacterController2DPlatform>().nextMoveCommand = Vector3.left * stepSize;
                player.transform.localScale = new Vector3(1,1,1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                player.GetComponent<CharacterController2DPlatform>().nextMoveCommand = Vector3.right * stepSize;
                player.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetKey(KeyCode.W) && climbArea.GetComponent<ClimbCheck>().climbing)
            {
                player.GetComponent<CharacterController2DPlatform>().nextMoveCommand = Vector3.up * stepSize;
                player.GetComponent<Rigidbody2D>().gravityScale = 2;
            }
            else
                player.GetComponent<CharacterController2DPlatform>().nextMoveCommand = Vector3.zero;
        }
    }
}