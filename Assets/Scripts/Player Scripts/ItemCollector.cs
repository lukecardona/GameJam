using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int Strawberries = 0;
    private Animator anim;
    private BoxCollider2D box;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            box = collision.gameObject.GetComponent<BoxCollider2D>();
            box.enabled = false;
            anim.SetTrigger("collect");
            collectSoundEffect.Play();
            cherries++;
            Debug.Log(cherries);
        }
    }
}
