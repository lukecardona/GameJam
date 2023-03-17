using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect: MonoBehaviour
{
    private int collectables = 0;
    [SerializeField] private Text CollectibleText;
    //private Animator anim;
    //private BoxCollider2D box;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            //anim = collision.gameObject.GetComponent<Animator>();
            //box = collision.gameObject.GetComponent<BoxCollider2D>();
            //box.enabled = false;
            //anim.SetTrigger("collect");
            //collectSoundEffect.Play();
            Destroy(collision.gameObject);
            collectables++;
            CollectibleText.text = "Collectables: " + (collectables);
            Debug.Log(collectables);
        }
    }
}
