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
    private float speed = 5f;
 
    public bool checkrun = false;
    public bool checkjump = false;
    public bool checkcrawl = false;
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
        Flip(directX, checkrun);
        Quaternion localrotation = Quaternion.Euler(0f,transform.localRotation.y,0f);
        if(directY < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, transform.localRotation.y, -90f);
            checkcrawl = !checkcrawl;
            charAction(checkjump, checkcrawl);


        }
        else if (directY > 0f) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, directX * speed);
            checkjump = !checkjump;
            charAction(checkjump, checkcrawl);
        }
        else
        {
            charAction(checkjump, checkcrawl);
        }
        Debug.Log(checkjump);




    }
    void Flip(float directX, bool checkrun){
        if (directX < 0f)
        {
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anime.SetBool("Running", !checkrun);

        }
        else if (directX > 0f)
        {
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anime.SetBool("Running", !checkrun);
        }
        else
        {
            anime.SetBool("Running", checkrun);
        }
    }
    void charAction(bool checkjump, bool checkcrawl)
    {
        anime.SetBool("Crawling", checkcrawl);
        anime.SetBool("Jumping", checkjump);
    }

}