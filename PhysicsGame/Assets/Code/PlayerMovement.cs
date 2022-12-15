using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer spr;
    private enum MovingState {Idle, Run, Jump, Fall }
    private BoxCollider2D col;
    public AudioSource jumpSound;

    // Can only be accessed from this script
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpSpeed = 15f;
    [SerializeField] private LayerMask JumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jumping
        if(Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpSound.Play();
        }

        // Moving left and right 
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

        AnimationsUpdate();
    }

    // Changing animations
    private void AnimationsUpdate()
    {
        MovingState State;

        if (dirX > 0f)
        {
            // Run right
            State = MovingState.Run;
            spr.flipX = false;
        }
        else if (dirX < 0f)
        {
            // Run left
            State = MovingState.Run;
            spr.flipX = true;
        }
        else
        {
            State = MovingState.Idle;
        }

        if(rb.velocity.y > .1f)
        {
            // Jump
            State = MovingState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            // Fall
            State = MovingState.Fall;
        }

        anim.SetInteger("State", (int)State);
    }

    private bool OnGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
}
