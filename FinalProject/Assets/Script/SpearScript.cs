using System.Collections;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2d;
    public float force;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb2d.velocity = new Vector2(direction.x, 0).normalized * force;
    }


    // Update is called once per frame
    void Update()
    {

    }
}