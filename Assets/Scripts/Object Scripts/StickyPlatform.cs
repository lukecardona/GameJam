using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //Work with one player convert to tag for more than one player
        {
            collision.gameObject.transform.SetParent(transform); //Set Player as child
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //Work with one player convert to tag for more than one player
        {
            collision.gameObject.transform.SetParent(null); //Set Player as child
        }
    }
}
