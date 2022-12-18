using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    BoxCollider2D box2d;
    Rigidbody2D rb2d;
    SpriteRenderer sprite;
    GameObject player;

    void Awake()
    {
        // get handles to components
        animator = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool flip;
    public void Flip(bool isFacingRight)
    {
        Vector3 scale = transform.localScale;

        if (isFacingRight)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }

        transform.localScale = scale;
    }
}
