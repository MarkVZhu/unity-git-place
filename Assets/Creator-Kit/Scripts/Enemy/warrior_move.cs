using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warrior_move : MonoBehaviour
{
    private Rigidbody2D rb;
    public  Transform leftpoint,rightpoint;
    private bool isleft = true;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement(){
        if (isleft){
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if (transform.position.x < leftpoint.position.x){
                transform.localScale = new Vector3(-1,1,1);
                isleft = false;
            }
        }else{
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightpoint.position.x){
                transform.localScale = new Vector3(1,1,1);
                isleft = true;
            }
        }
    }
}
