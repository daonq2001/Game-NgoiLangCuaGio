using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 move;
    private Vector2 face;

    public List<Sprite> sprites;

    public GameObject odat, carot;
    public GameObject chon;
    public float speed;
    private float TimeStart = 10f;
    private string str;

    public Text timeTree;

    private List<GameObject> listOdat = new List<GameObject>();

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(TimeStart >= 0f)
        {
            TimeStart -= Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(TimeStart);
        str = time.ToString(@"hh\:mm\:ss"); 
        timeTree.text = str;
        if(TimeStart <= 5f && TimeStart >= 0f)
        {
            for (int i = 0; i < listOdat.Count; i++)
            {
                listOdat[i].GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
        }
        if(TimeStart <= 0f)
        {
            for (int i = 0; i < listOdat.Count; i++)
            {
                listOdat[i].GetComponent<SpriteRenderer>().sprite = sprites[2];
            }
        }
    }

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
        Chon();
    }

    private void Chon()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        chon.SetActive(true);
        chon.transform.position = hit.transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && hit.collider.gameObject.CompareTag("Nen dat"))
        {
            Instantiate(odat, chon.transform.position, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && hit.collider.gameObject.CompareTag("Odat"))
        {
            GameObject cr = Instantiate(carot, chon.transform.position, Quaternion.identity);
            cr.GetComponent<SpriteRenderer>().sprite = sprites[0];
            listOdat.Add(cr);
        }
    }


}
