using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_player : MonoBehaviour
{
    Animator Anim;
    Rigidbody2D rb;
    int time = -1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((rb.velocity.x!=0)&&(transform.parent == null))
        {
            Anim.SetBool("speed0", false);
        }
        else
        {
            Anim.SetBool("speed0", true);
        }
        if (time > -1) 
        {
            time++;
            if (time > 50)
            {
                Anim.SetBool("sex", false);
                time = -1;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Plat"))
        {
            Anim.SetBool("speed0", true);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            Anim.SetBool("sex", true);
            time = 0;
        }
    }
}
