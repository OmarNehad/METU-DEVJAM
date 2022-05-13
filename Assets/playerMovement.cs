using UnityEngine;
using System;
public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sides = 100f;
    public float jumpVelocity = 100f;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask; 

    private void Awake() 
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>(); 
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        else if (Input.GetKey("d")) 
        {
            rb.AddForce(new Vector2(sides, 0)); 
        }
        else if (Input.GetKey("a")) 
        {
            rb.AddForce(new Vector2(-sides, 0)); 
        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D  raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}