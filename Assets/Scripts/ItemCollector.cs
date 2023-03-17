using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int collectibles = 0;

    [SerializeField] private Text CollectibleText;

    private void OnTriggerEnter2D(Collider2D collision) //Tick the "Is Trigger" box in box collider 2D in Unity of the collectibe item of 
    {
        if (collision.gameObject.CompareTag("Collectible item"))//Make sure to make a tag in Unity of "Collectible item" and attach it to the item
        {
            Destroy(collision.gameObject);
            collectibles++;
            CollectibleText.text = "Collectables: " + collectibles;
        }
    }
}
