using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    private Rigidbody2D rb;
    public Text count;
    // Start is called before the first frame update
    void Start()
    {
        count.text = "9";
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.y < -20)
        {
            count.text = (int.Parse(count.text) - 1).ToString();
            if (int.Parse(count.text) == 0)
                Destroy(gameObject);
            else
            {
                transform.position = new Vector2(0, 0);
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ship"))
        {
            count.text = (int.Parse(count.text) - 1).ToString();
        }
        
        if (int.Parse(count.text) == 0)
            Destroy(gameObject);
    }
}
