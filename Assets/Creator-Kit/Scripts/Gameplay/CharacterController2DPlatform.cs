using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple controller for animating a 4 directional sprite using Physics.
    /// </summary>
    public class CharacterController2DPlatform : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        public Animator animator;
        public bool flipX = false;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        [Header("Jump Settings")]
        [Tooltip("The force with which the player jumps.")]
        public float jumpPower = 10.0f;
        [Tooltip("The number of jumps that the player is alowed to make.")]
        public int allowedJumps = 1;
        [Tooltip("The duration that the player spends in the \"jump\" state")]
        public float jumpDuration = 0.8f;
        [Tooltip("The effect to spawn when the player jumps")]
        public GameObject jumpEffect = null;
        [Tooltip("Layers to pass through when moving upwards")]
        public List<string> passThroughLayers = new List<string>();

        // The number of times this player has jumped since being grounded
        private int timesJumped = 0;
        // Whether the player is in the middle of a jump right now
        private bool jumping = false;

        public LayerMask WhatIsGround;
        public GameObject groundChecker; 
        public bool isGround;

        public GameObject shedow;

        enum State
        {
            Idle, Moving,Jump,Fall
        }

        State state = State.Idle;
        Vector3 start, end;
        Vector2 currentVelocity;
        float startTime;
        float distance;
        float velocity;

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                start = transform.position;
                end = start + nextMoveCommand;
                distance = (end - start).magnitude;
                velocity = 0;
                UpdateAnimator(nextMoveCommand);
                nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            velocity = Mathf.Clamp01(velocity + Time.deltaTime * acceleration);
            UpdateAnimator(nextMoveCommand);
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            //spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
        }

        public void JumpInput()
        {
            //Debug.Log("Get Jump Input");
            StartCoroutine("Jump", 1.0f);
        }

        void Jump(float powerMultiplier = 1.0f)
        {
            //Debug.Log("Jump");
            // state = State.Jump;
            if (isGround)
            {
                //Debug.Log("Yes Ground: Jump");
                jumping = true;
                float time = 0;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                rigidbody2D.AddForce(transform.up * jumpPower * powerMultiplier, ForceMode2D.Impulse);
                timesJumped++;
                while (time < jumpDuration)
                {
                    time += Time.deltaTime;
                }
                jumping = false;
            }
        }

        void UpdateAnimator(Vector3 direction)
        {
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
            }
        }

        void Update()
        {
            isGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.1f, WhatIsGround);
            if (isGround && (shedow.activeInHierarchy == false)) shedow.SetActive(true);
            else if (!isGround && shedow.activeInHierarchy) shedow.SetActive(false);
            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }
        }

        void LateUpdate()
        {
            if (pixelPerfectCamera != null)
            {
                transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
            }
        }

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
        }
    }
}