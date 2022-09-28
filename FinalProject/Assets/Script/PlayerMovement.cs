using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float direct = 0f;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direct = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(direct * speed, GetComponent<Rigidbody2D>().velocity.y);
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        if (Input.GetKeyDown("space"))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);

            Debug.Log("Jumped");
        }
        /*        else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }*/

    }

}