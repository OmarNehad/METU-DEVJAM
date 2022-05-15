using UnityEngine;
using System;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float sides = 38f;
    public float jumpVelocity = 100f;
    private PolygonCollider2D polygonCollider2D;
    private EdgeCollider2D edgeCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource simitEating;
    [SerializeField] private AudioSource drinkingTea;

    private bool isRendered = false;

    private Animator playerAnim;

    private bool doubleJump = false;

    private bool isWall;

    private int jumps;

    public bool groundBool;

    public GameObject deathmenu;

    private void Awake() 
    {
        deathmenu.SetActive(false);
        playerAnim = gameObject.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
        edgeCollider2D = transform.GetComponent<EdgeCollider2D>();
    }

    private void OnRenderObject()
    {

        isRendered = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PowerUp")
        {
            simitEating.Play();
            doubleJump = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "shay")
        {
            drinkingTea.Play();
            doubleJump = true;
            Destroy(collision.gameObject);
        }
        else
        {
                isWall = true;

        }
    }

    private void Update()
    {

        playerAnim.SetFloat("Velocity", rb.velocity.y);
        transform.rotation = Quaternion.identity;

        if (isRendered && !gameObject.GetComponent<SpriteRenderer>().isVisible)
        {

            
            deathmenu.SetActive(true);
            


        }


        if (isWall)
        {
            groundBool = false;
            playerAnim.SetBool("IsJumping", true);

        }
        else
        {
            groundBool = IsGrounded();
            playerAnim.SetBool("IsJumping", !groundBool);

        }

        if ((groundBool || (doubleJump && jumps < 2)) && Input.GetKeyDown(KeyCode.Space))
        {  
            jumpSound.Play();   
            jumps += 1;
            rb.velocity = Vector2.up * jumpVelocity;
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
        if (Physics2D.BoxCast(polygonCollider2D.bounds.center, polygonCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
        //Debug.Log(raycastHit2d.collider);
        //playerAnim.SetBool("IsJumping");   
    }
}