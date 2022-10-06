using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rigidbody;
    private Animator anime;
    private Collider collider;

    private float directX = 0f;
    private float directY = 0f;
    private float speed = 2f;

    public bool checkrun;
    public bool checkjump;
    public bool checkcrawl;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        directX = Input.GetAxisRaw("Horizontal");
        directY = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
        Flip(directX,checkrun);
        localrotation = transform.localRotation.y;
        if(directY < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, transform.localRotation.y, 90f);
            checkjump = !checkjump;
            
        }
        else if (directY > 0f) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, directX * speed);
            checkcrawl = !checkcrawl;
        }
        else
        {
            checkjump = !checkjump;
        }
        charAction(checkjump, checkcrawl);




    }
    void Flip(float directX, bool checkrun){
        if (directX < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anime.SetBool("Running", checkrun);

        }
        else if (directX > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anime.SetBool("Running", checkrun);
        }
        else
        {
            anime.SetBool("Running", !checkrun);
        }
    }
    void charAction(bool checkjump, bool checkcrawl, bool checkrun)
    {
        if (checkjump)
        {
            anime.SetBool("Jumping", checkjump);
            anime.SetBool("Crawling", checkcrawl);

        }
        else if (checkcrawl)
        {
            anime.SetBool("Crawling", checkcrawl);
            anime.SetBool("Jumping", checkjump);
        }
    }

}