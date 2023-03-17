using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    // Loads the start screen
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Start");
    }
}
