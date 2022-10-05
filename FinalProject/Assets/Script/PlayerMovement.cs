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
        if (directX < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            anime.SetBool("Running", true);
  
        }
        else if(directX > 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            rigidbody.velocity = new Vector2(directX * speed, rigidbody.velocity.y);
            anime.SetBool("Running", true);
        }
        else{
            anime.SetBool("Running", false);
        }
        VerticalChange(directY);


    }
    void VerticalChange(float directY){
        if (directY < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            anime.SetBool("Crawling", true);
        }
        else if(directY > 0f)
        {
            rigidbody.velocity = new Vector2(0, 7);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anime.SetBool("Jumping", true);
            anime.SetBool("Crawling", false);
        }
        else{
            anime.SetBool("Jumping", false);
            anime.SetBool("Crawling", false);
        }
    }

}