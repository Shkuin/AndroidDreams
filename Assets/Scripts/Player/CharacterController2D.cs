﻿using UnityEngine;

// This script is a basic 2D character controller that allows
// the player to run and jump. It uses Unity's new input system,
// which needs to be set up accordingly for directional movement
// and jumping buttons.

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    [Header("Movement Params")]
    public float runSpeed = 6.0f;
    //public float jumpSpeed = 8.0f;
    public float gravityScale = 0.0f;
    public float forceCoef;

    // components attached to player
    //private BoxCollider2D _coll;
    private Rigidbody2D _rb;

    // other
    //private bool isGrounded = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.gravityScale = gravityScale;
    }

    private void FixedUpdate()
    {
        //UpdateIsGrounded();
        HandleHorizontalMovement();
        //HandleJumping();
    }


    /*private void UpdateIsGrounded()
    {
        Bounds colliderBounds = _coll.bounds;
        float colliderRadius = _coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        this.isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != _coll)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }*/

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        _rb.AddForce(moveDirection * runSpeed * forceCoef, ForceMode2D.Force);
    }



    /*private void HandleJumping()
    {
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (isGrounded && jumpPressed)
        {
            isGrounded = false;
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
    }*/

}