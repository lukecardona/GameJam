using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleEnemyAnimations : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Rigidbody2D rb;
    private GameObject enemy;
    [SerializeField] private Slider slider;
    [SerializeField] private int DamageAmount = 200;
    private enum MovementAnimationState
    {
        idle, running
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemy = GetComponent<GameObject>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementAnimationState state;
        if (rb.velocity.x  < -0.05f)
        {
            state = MovementAnimationState.running;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            sprite.flipX = false;
        }
        else if (rb.velocity.x > -0.05f)
        {
            state = MovementAnimationState.running;
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            state = MovementAnimationState.idle;
        }
        anim.SetInteger("state", (int)state);
    }
    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}