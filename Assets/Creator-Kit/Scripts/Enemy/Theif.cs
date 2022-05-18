using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theif : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed=1f;
    private Collider2D coll;
    public Transform leftHighPoint, leftLowPoint,rightHighPoint,rightLowPoint;
    private Animation anim;

    private bool faceLeft=true; //juding whether the theif is facing left
    private bool isTop=true;      //judge whether the theif is at the upper edge of the walking path
    private bool isGoDown = false; //judge whether the theif is going down at the left edge
    private bool isGoUp = false;    //judge whether the theif is going up at the right edge

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        coll.GetComponent<Collider2D>();

        transform.DetachChildren();


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //SwitchAnim();
    }

    //theif moves counter clockwise on the box-shaped path
    void Movement()
    {
        //theif is moving at the upper edge of the box, towarding left
        if(faceLeft&&isTop&&!isGoDown&&!isGoUp)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
 
            if(transform.position.x<leftHighPoint.position.x)
            {
                transform.localScale = new Vector3(1, -1, 1);
                isTop = false;
                faceLeft = false;
                isGoDown = true;
            }
        }//enemy is at the left edge, going down
        else if(!isTop&&!faceLeft&&!isGoUp && isGoDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);

            if(transform.position.y<leftLowPoint.position.y)
            {
                transform.localScale = new Vector3(-1, -1, 1);
                isGoDown = false;
            }
        }//enemy is on the bottom edge, facing right
        else if(!faceLeft&&!isTop&&!isGoDown&&!isGoUp)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if(transform.position.x>rightLowPoint.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isGoUp = true;
            }
        }//enemy is on right edge,going up
        else if(!faceLeft && !isTop && !isGoDown&&isGoUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);

            if (transform.position.y > rightHighPoint.position.y)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isGoUp = false;
                isGoDown = false;
                isTop = true;
                faceLeft = true;
            }
        }
    }


    void SwitchAnim()
    {

    }
}
