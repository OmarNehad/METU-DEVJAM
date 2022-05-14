using UnityEngine;
using System;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float sides = 38f;
    public float jumpVelocity = 100f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;

    private bool isRendered = false;

    private Animator playerAnim;

    private bool doubleJump = false;

    public int jumps;

    private void Awake() 
    {
        playerAnim = gameObject.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>(); 
    }

    private void OnRenderObject()
    {

        isRendered = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PowerUp")
        {
            doubleJump = true;
            Destroy(collision.gameObject);
        }
    }
    
    private void Update()
    {

        if (isRendered && !gameObject.GetComponent<SpriteRenderer>().isVisible)
        {

            HealthControl.Instance.DecreaseHelath();
            transform.position = Vector3.zero;
            if (HealthControl.Instance.health == 0)
            {
                //TODO : SHOW MENU
            }
            
        }

        var groundBool = IsGrounded();
        if ((groundBool || (doubleJump && jumps < 2)) && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("IsJumping", true);
            jumps += 1;
            rb.velocity = Vector2.up * jumpVelocity;
        }
        else
        {
            playerAnim.SetBool("IsJumping", false);

        }
        if (groundBool && jumps == 2)
        {
            jumps = 0;
            doubleJump = false;

        }
        handlemovement();
    }

    private void handlemovement()
    {
        if (Input.GetKey("d"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            playerAnim.SetBool("IsMoving", true);
            rb.velocity = new Vector2(sides, rb.velocity.y);

        }
        else if (Input.GetKey("a"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            playerAnim.SetBool("IsMoving", true);
            rb.velocity = new Vector2(-sides, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            playerAnim.SetBool("IsMoving", false);

        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D  raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        //Debug.Log(raycastHit2d.collider);
        //playerAnim.SetBool("IsJumping");
        return raycastHit2d.collider != null;
    }
}