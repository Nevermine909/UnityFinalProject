using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float direct = 0f;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direct = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(direct * speed, rigidbody.velocity.y);
        FlipChar(direct);
        Debug.Log(rigidbody.velocity);
        if (Input.GetKeyDown("space"))
        {
            rigidbody.velocity = new Vector2(0, 7);
            Debug.Log("Jumped");
        }

    }
    void FlipChar(float direct)
    {
        if (direct < 0f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(direct > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); ;
        }
    }

}