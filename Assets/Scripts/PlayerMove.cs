using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float speed0;
    public float jump;
    private Vector2 force;
    private Rigidbody2D rb;
    private bool faceRight = false;
    private bool inAir = false;
    private int time;
    private bool one_jump, double_jump = false;
    void Start()
    {
        force = new Vector2(0, jump);
        speed0 = speed;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (faceRight)
                flip();
            if (inAir)
            {
                speed = speed / 2;
            }
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (inAir)
            {
                speed = speed / 2;
            }
            if (!faceRight)
                flip();
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (!inAir)
            {
                one_jump = true;
                inAir = true;
                rb.AddForce(force);
            }
            else
            if (double_jump)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(force);
                one_jump = false;
                double_jump = false;
            }
        }
        
        if (one_jump)
        {
            time++;
            if ((time<50)&&(time>10))
            {
                if (inAir)
                {
                    one_jump = false;
                    double_jump = true;
                    time = 0;
                }
            }
        }
        if (inAir)
            speed = speed0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer == LayerMask.NameToLayer("Ground"))|| (collision.gameObject.layer == LayerMask.NameToLayer("Plat")))
        {
            one_jump = false;
            double_jump = false;
            speed = speed0;
            inAir = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ice"))
        {
            one_jump = false;
            double_jump = false;
            speed = speed0 * 4;
            inAir = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Smola"))
        {
            one_jump = false;
            double_jump = false;
            speed = speed0 / 5;
            inAir = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ship"))
        {
            one_jump = false;
            double_jump = false;
            rb.AddForce(force);
            inAir = false;
        }
    }


    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
