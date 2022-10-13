using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D rigidBody;
    private Animator animate;
    private Collider collider;

    private float directX = 0f;
    private float speed = 5f;
 
    public bool checkRun = false;
    public bool checkJump = false;
    public bool onGroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {   
        directX = Input.GetAxisRaw("Horizontal");
        Flip(directX, checkRun);
        if (Input.GetKeyDown("space") && onGroundCheck) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 7);
            charAction(!checkJump);
            onGroundCheck = false;
        }
        /*else
        if (Input.GetKeyUp("space") && !onGroundCheck)
        {
            onGroundCheck = true;
        }
        else
        if (Input.GetKeyDown("space") && !onGroundCheck)
        {
            Debug.Log("can not jump");
            charAction(!checkJump);
            onGroundCheck = false   ;
        }*/
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGroundCheck = true;
            charAction(checkJump);
            Debug.Log(onGroundCheck);
        }
    }

    void Flip(float directX, bool checkrun){
        if (directX < 0f)
        {
            rigidBody.velocity = new Vector2(directX * speed, rigidBody.velocity.y);
            transform.localScale = new Vector3(-0.070115909f, 0.0701159164f, 0.0701159164f);
            /*transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);*/
            animate.SetBool("Running", !checkrun);

        }
        else if (directX > 0f)
        {
            rigidBody.velocity = new Vector2(directX * speed, rigidBody.velocity.y);
            transform.localScale = new Vector3(0.070115909f, 0.0701159164f, 0.0701159164f);
            /*transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);*/
            animate.SetBool("Running", !checkrun);
        }
        else
        {
            /*rb.velocity = new Vector2(0, rb.velocity.y);*/
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animate.SetBool("Running", checkrun);
        }
    }
    void charAction(bool checkjump)
    {
        animate.SetBool("Jumping", checkjump);
    }

}