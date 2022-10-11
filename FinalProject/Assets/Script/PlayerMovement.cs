using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rigidbody;
    private Animator animate;
    private Collider collider;

    private float directX = 0f;
    private float speed = 5f;
 
    public bool checkrun = false;
    public bool checkjump = false;
    public bool checkcrawl = false;
    public bool ongroundcheck;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        directX = Input.GetAxisRaw("Horizontal");

        Flip(directX, checkrun);
        if (Input.GetKeyDown("space") && ongroundcheck) {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 7 );
            charAction(!checkjump);
            ongroundcheck = false;
        }


    

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            ongroundcheck = true;
            charAction(checkjump);
            Debug.Log(ongroundcheck);
        }
    }

    void Flip(float directX, bool checkrun){
        if (directX < 0f)
        {
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0f, -180f, transform.localRotation.z * -90f);
            Debug.Log(transform.rotation);
            animate.SetBool("Running", !checkrun);

        }
        else if (directX > 0f)
        {
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, transform.localRotation.z * -90f);
            animate.SetBool("Running", !checkrun);
        }
        else
        {
            animate.SetBool("Running", checkrun);
        }
    }
    void charAction(bool checkjump)
    {
        animate.SetBool("Jumping", checkjump);
    }

}