using UnityEngine;
using System;
public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sides = 38f;
    public float jumpVelocity = 100f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;

    private Animator playerAnim;

    private void Awake() 
    {
        playerAnim = gameObject.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>(); 
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        handlemovement();
    }

    private void handlemovement()
    {
        if (Input.GetKey("d"))
        {
            playerAnim.SetBool("IsMoving", true);
            rb.velocity = new Vector2(sides, rb.velocity.y);

        }
        else if (Input.GetKey("a"))
        {
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
        RaycastHit2D  raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        //Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}