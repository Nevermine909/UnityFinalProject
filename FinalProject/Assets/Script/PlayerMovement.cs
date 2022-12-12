using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animate;
    private BoxCollider2D coll;

    private float directX = 0f;
    private float speed = 6f;
    private float jumpAmount = 12f;

    private bool checkRun = false;
    private bool checkJump = false;
    private bool checkFall = false;
    public bool onGroundCheck;

    public float gravityScale = 1;
    public float fallingGravityScale = 3;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        directX = Input.GetAxisRaw("Horizontal");
        Flip(directX, checkRun);
        
        if (Input.GetKey("space") && IsGrounded())
        {   
            jumpSound.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpAmount);
        }
        else
        {
            if (rigidBody.velocity.y >= 0)
            {
                rigidBody.gravityScale = gravityScale;
            }
            else if (rigidBody.velocity.y < 0)
            {
                rigidBody.gravityScale = fallingGravityScale;
                animate.SetBool("Falling", !checkFall);
            }
        }

        if (!IsGrounded())
        {
            charAction(!checkJump);
        }
        else
        {
            charAction(checkJump);
            animate.SetBool("Falling", checkFall);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    void Flip(float directX, bool checkrun){
        if (directX < 0f)
        {
            rigidBody.velocity = new Vector2(directX * speed, rigidBody.velocity.y);
            transform.localScale = new Vector3(-0.070115909f, 0.0701159164f, 0.0701159164f);
            animate.SetBool("Running", !checkrun);

        }
        else if (directX > 0f)
        {
            rigidBody.velocity = new Vector2(directX * speed, rigidBody.velocity.y);
            transform.localScale = new Vector3(0.070115909f, 0.0701159164f, 0.0701159164f);
            animate.SetBool("Running", !checkrun);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animate.SetBool("Running", checkrun);
        }
    }
    void charAction(bool checkjump)
    {   
        animate.SetBool("Jumping", checkjump);
    }

}