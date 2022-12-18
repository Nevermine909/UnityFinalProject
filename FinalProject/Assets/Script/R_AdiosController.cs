using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class R_AdiosController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    BoxCollider2D box2d;
    GameObject player;
    EnemyController enemyController;

    public GameObject spear;
    public Transform spearPos;

    private float timer;

    bool isFacingRight;
    bool isGrounded;
    bool isJumping;
    bool isTakingDamage;
    bool flip;

    bool canJump = true;
    bool canThrow;
    int spearThrowCount;

    float playerDistance;

    [SerializeField] float jumpHeight;

    [SerializeField] bool enableAI;

    [SerializeField] Vector3 sourcePosition;
    [SerializeField] Vector3 targetPosition;

    [SerializeField] float gravity;
    [SerializeField] float height = 1f;
    [SerializeField] float targetOffset = 10f;

    int count;
    public enum MoveDirections { Left, Right };
    [SerializeField] MoveDirections moveDirection = MoveDirections.Left;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = false;

        if (moveDirection == MoveDirections.Right)
        {
            isFacingRight = true;
            enemyController.Flip(isFacingRight);
        }

        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        enemyController = GetComponent<EnemyController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        isGrounded = false;

        RaycastHit2D raycastHit;

        float raycastDistance = 0.05f;
        int layerMask = 1 << LayerMask.NameToLayer("Ground");

        Vector3 box_origin = box2d.bounds.center;
        box_origin.y = box2d.bounds.min.y + (box2d.bounds.extents.y / 4f);
        Vector3 box_size = box2d.bounds.size;
        box_size.y = box2d.bounds.size.y / 4f;
        raycastHit = Physics2D.BoxCast(box_origin, box_size, 0f, Vector2.down, raycastDistance, layerMask);

        if (raycastHit.collider != null)
        {
            isGrounded = true;
            if (isJumping)
            {
                canJump = true;
                isJumping = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        playerDistance = Vector2.Distance(player.transform.position, transform.position);

        /*if (enableAI)
        {
            if (isGrounded)
            {
                if (canJump)
                {
                    Jump();
                    count++;
                }
            }
            else
            {
                isJumping = true;
            }
            
            if (count == 3)
            {
                Exhausted();
            }
        }*/

        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gravity == 0) gravity = Physics2D.gravity.y;
            Vector3 bombPos = transform.position;
            Vector3 playerPos = player.transform.position;
            if (targetOffset != 0) playerPos.x += targetOffset;
            rb2d.velocity = UtilityFunctions.CalculateLaunchData(bombPos, playerPos, height, gravity).initialVelocity;
        }
    }

    void shoot()
    {
        Debug.Log(spearPos.position);
        Instantiate(spear, spearPos.position, Quaternion.identity);
    }

    void ThrowSpear()
    {
        // the animaion event calls for launching the bomb - Launch()
        animator.Play("BombMan_Throw");
        animator.speed = 1;
        // bombman has to wait until the bomb explodes before doing anything else
        canThrow = false;
        canJump = false;
        // one less bomb to throw
        spearThrowCount--;
    }

    void Jump()
    {
        if (canJump)
        {
            Debug.Log("Jump");

            float distanceFromPlayer = player.transform.position.x - transform.position.x;

            rb2d.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            canJump = false;
        }
    }

    void Exhausted()
    {
        canJump = false;
        count = 0;
        Debug.Log("Exhausted");
    }

    void Shockwave()
    {

    }

    int ChooseSpearCount()
    {
        float[] probabilities = { 10, 20, 70 };

        float total = 0;

        foreach (float prob in probabilities)
        {
            total += prob;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probabilities.Length; i++)
        {
            if (randomPoint < probabilities[i])
            {
                return i + 1;
            }
            else
            {
                randomPoint -= probabilities[i];
            }
        }
        return probabilities.Length;
    }

    public void EnableAI(bool enable)
    {
        this.enableAI = enable;
    }
    public void Flip()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
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
