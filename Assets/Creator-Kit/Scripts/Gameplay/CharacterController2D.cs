using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple controller for animating a 4 directional sprite using Physics.
    /// </summary>
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public Vector3 nextMoveCommand;
        public Animator animator;
        public bool flipX = false;
        public int medicine = 0;
        public Text MedicineNum;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        public LayerMask WhatIsGround;

        public bool isGround;
        private bool isHurt;

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
            //静止态接到命令，向运动态过渡
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

            //SmoothDamp: 当前位置，目标位置，当前速度，时间间隔，最终速度
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            //在X轴上翻转精灵
            spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? true : false;
        } 

        void UpdateAnimator(Vector3 direction)
        {
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
            }
            if(isHurt)
            {
                //animator.SetBool("hurt", true);
                animator.SetFloat("WalkY", 0);
                animator.SetFloat("WalkX", 0);
                if (Mathf.Abs(rigidbody2D.velocity.x) < 0.1f)
                {
                    animator.SetBool("hurt", false);
                    animator.SetInteger("WalkX", 1);
                    animator.SetInteger("WalkY", 1);
                    isHurt = false;
                }
            }
        }

        void Update()
        {
            //判断碰撞体是否掉到了圆域里 (圆形中心，圆形半径，筛选器)
            isGround = Physics2D.OverlapCircle(this.transform.position, 0.025f, WhatIsGround);
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

      
        private void OnTriggerEnter2D(Collider2D other) {
            //碰到敌人重新加载场景
            if (other.tag == "Enemy"){
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(index);
            }
            //进门隐藏kitchen_over
            if(other.tag == "floor"){
                GameObject.Find("Kitchen_over").gameObject.SetActive(false);
            }
            if(other.tag == "backgroud"){
                // Destroy(other.gameObject);
                Transform over = transform.Find("/World").Find("Tilemaps").Find("Kitchen_over");
                 over.gameObject.SetActive(true);
            }

            //碰到药瓶就销毁他，并且计数+1,角色喝药以后全身抖动
            if(other.tag=="Medicine")
            {
                Destroy(other.gameObject);
                medicine += 1;
                MedicineNum.text = medicine.ToString();


                if (transform.position.x < other.gameObject.transform.position.x)
                {
                    rigidbody2D.velocity = new Vector2(-5,rigidbody2D.velocity.y);
                    isHurt = true;
                }
                else if(transform.position.x > other.gameObject.transform.position.x)
                {
                    rigidbody2D.velocity = new Vector2(5, rigidbody2D.velocity.y);
                    isHurt = true;
                }
                else if (transform.position.y > other.gameObject.transform.position.y)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,5);
                    isHurt = true;
                }
                else if (transform.position.y < other.gameObject.transform.position.y)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -5);
                    isHurt = true;
                }

            }
        }



        //喝下3瓶药后，在屏幕上显示提示文字
        private void ShowOnScreen()
        {
            if(medicine==3)
            {
                //显示一些话
            }
        }
    }
}