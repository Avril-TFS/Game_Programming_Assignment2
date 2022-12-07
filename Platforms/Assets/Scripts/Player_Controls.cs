using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    private bool isGrounded = false;
    private float speed = 10.0f;

    private Transform playerGroundCheck;
    [SerializeField] private LayerMask Ground;
    private float JumpForce = 500.0f;

    private Rigidbody2D rg2d;
    private BoxCollider2D box2d;

    private float maxSpeed = 1.0f;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float hrz = Input.GetAxis("Horizontal");

        isGrounded = GroundCheck();
        if (isGrounded && Input.GetAxis("Jump") == 1)
        {
            rg2d.AddForce(new Vector2(0.0f, JumpForce));
            if(rg2d.velocity.magnitude > maxSpeed)
            {
                rg2d.velocity = Vector2.ClampMagnitude(rg2d.velocity, maxSpeed);
            }
            isGrounded = false;
        }
        
        rg2d.velocity = new Vector2(hrz * speed, rg2d.velocity.y);
    }

    private bool GroundCheck()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(box2d.bounds.center, Vector2.down, box2d.bounds.extents.y + extraHeight, Ground);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            isGrounded = true;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(box2d.bounds.center, Vector2.down * (box2d.bounds.extents.y + extraHeight), rayColor);
        return raycastHit.collider != null;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Hazard"))
        {
            ResetPlayer();
        }
    }
    void ResetPlayer()
    {
        rg2d.velocity = new Vector2(0, 0);
        transform.position = new Vector2(-11, -1);
    }
}
