using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    bool jumping = true;
    float speed = 5;
    Animator ani;
    Rigidbody2D rb;
    bool faceright = true;
    SpriteRenderer sp;

    float horiz;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        horiz = Input.GetAxis("Horizontal");
        ani.SetFloat("run", Mathf.Abs(horiz));
    }

    void Movement()
    {
        rb.velocity = new Vector2(horiz * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumping)
        {
            jumping = false;
            ani.SetTrigger("Jump");
            rb.velocity = new Vector2(0, 7);
        }

        if (Input.GetKey(KeyCode.D) && !faceright)
        {
            faceright = true;
            sp.flipX = true;
        }
        if (Input.GetKey(KeyCode.A) && faceright)
        {
            faceright = false;
            sp.flipX = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = true;
    }
}
