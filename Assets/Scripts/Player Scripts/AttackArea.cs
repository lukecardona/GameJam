using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            //Play Box Animation
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enenmy");
            //Play Enemy Death animation Animation
            anim = collision.gameObject.GetComponent<Animator>();
            anim.SetTrigger("death");
            collision.enabled = false;
        }
    }
}

