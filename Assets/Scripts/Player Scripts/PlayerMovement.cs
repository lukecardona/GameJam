using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Create Variable to store RigidBody

    private Rigidbody2D playerRB;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D playerCollider;
    [SerializeField] private AudioSource jumpSoundEffect;
    private float dirX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalForce = 1f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementAnimationState {
        idle, running, jumping, falling
    }
    // Start is called before the first frame update
    private void Start()
    {
        //On Start Search for the RigidBody for the Player
        playerRB = GetComponent<Rigidbody2D>();
        //Search for Sprite and Animator
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //Search for Player Collider
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
   private void Update()
    {
        //Handle Horizantal Movement
        dirX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw goes to 0 immediately after releasing key
        //PlaterRB.velocity is the current y axis velocity
        playerRB.velocity = new Vector2(dirX * horizontalForce, playerRB.velocity.y);

        //Handle Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //jumpSoundEffect.Play Sound
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }

        UpdateAnimationState(dirX);
    }

   private void UpdateAnimationState(float dirX)
    {
        MovementAnimationState state; 
        if (dirX > 0f)
        {
            state = MovementAnimationState.running;
            sprite.flipX = false;
        } else if (dirX < 0)
        {
            state = MovementAnimationState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementAnimationState.idle;
        }

        if (playerRB.velocity.y > 0.1f)
        {
            state = MovementAnimationState.jumping;

        }else if(playerRB.velocity.y < -0.1f)
        {
            state = MovementAnimationState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
