using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=4;
    public float jumpSpeed=6;
    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Movimiento horizontal del personaje
        if(Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX=false;
            animator.SetBool("Run", true);
        } else
        if(Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX=true;
            animator.SetBool("Run", true);
        } else 
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        //Salto del personaje
        if(Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if(CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        } else 
        {
            animator.SetBool("Jump", false);
        }

        //Salto mejorado
        if(betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
        //ATACAR
        if(Input.GetKey("e"))
        {
            animator.SetBool("Attack", true);
        }
        else {
            animator.SetBool("Attack", false);
        }
    }
}
