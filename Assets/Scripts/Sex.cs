using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sex : MonoBehaviour
{
    private Rigidbody2D rb;
    public Text count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (int.Parse(count.text)<9)
                count.text = (int.Parse(count.text) + 1).ToString();
            Destroy(gameObject);
        }
    }
}
