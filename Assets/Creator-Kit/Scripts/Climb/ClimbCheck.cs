using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;

public class ClimbCheck : MonoBehaviour
{
    public bool climbing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !climbing)
        {
            climbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        climbing = false;
        GameObject.Find("Character").GetComponent<Rigidbody2D>().gravityScale = 5 ;
    }

}
