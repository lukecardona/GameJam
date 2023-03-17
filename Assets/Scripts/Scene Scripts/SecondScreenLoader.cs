using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondScreenLoader : MonoBehaviour
{
    // Loads the second screen
    public void LoadSecondScreen()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
