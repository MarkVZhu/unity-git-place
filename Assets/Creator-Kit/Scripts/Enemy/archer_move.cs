using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_move : MonoBehaviour
{
    private Rigidbody2D rb;
    public  Transform leftpoint,rightpoint;
    private bool isleft = true;
    public float speed;
    public float leftx,rightx;
    private Animator Anim;
    private Collider2D Coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();
        // transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement();
    }

    void Movement(){
        if (isleft){
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if (transform.position.x < leftx){
                transform.localScale = new Vector3(-1,1,1);
                isleft = false;
            }
        }else{
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx){
                transform.localScale = new Vector3(1,1,1);
                isleft = true;
            }
        }
    }
}
