using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 move;
    private Vector2 face;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.SqrMagnitude());
        
        if(move.x != 0 || move.y != 0)
        {
            face.x = move.x;
            face.y = move.y;
        }

        anim.SetFloat("FaceX", face.x);
        anim.SetFloat("FaceY", face.y);

        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}
