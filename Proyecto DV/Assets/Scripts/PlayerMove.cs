using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float runSpeed=4;
    public float jumpSpeed=5;
    public float wallSlidingSpeed=1;
    public float wallJumpSpeed=3;
    public static float state=1;
    Rigidbody2D rb2D;

    public bool betterJump = false;
    public bool wallSliding = false;

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
        //MOVIMIENTO HORIZONTAL DEL PERSONAJE
        if(Input.GetKey("d") && !Input.GetKey("e"))
        {
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX=false;
            animator.SetBool("Run", true);
        } else
        if(Input.GetKey("a") && !Input.GetKey("e"))
        {
            rb2D.velocity = new Vector2(-runSpeed,rb2D.velocity.y);
            spriteRenderer.flipX=true;
            animator.SetBool("Run", true);
        } else 
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        //RAPEL EN PARED
        if(WallCheck.isWalled && CheckGround.isGrounded==false && (Input.GetKey("a") || Input.GetKey("d")))
        {
            wallSliding = true;
        } else
        {
            wallSliding = false;
        }
        if(wallSliding)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        //SALTO DEL PERSONAJE
        if(Input.GetKey("space") && !Input.GetKey("e") && (CheckGround.isGrounded || WallCheck.isWalled))
        {
            if(!WallCheck.isWalled )
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            } 
            else {
                rb2D.velocity = new Vector2(rb2D.velocity.x, wallJumpSpeed);
            }
        }
        if(CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        } else 
        {
            animator.SetBool("Jump", false);
        }

        //SALTO MEJORADO
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
            animator.SetBool("Fire", true);
        }
        else {
            animator.SetBool("Fire", false);
        }
    }
}
