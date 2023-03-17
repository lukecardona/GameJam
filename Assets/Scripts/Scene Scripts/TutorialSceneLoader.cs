using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneLoader : MonoBehaviour
{
    // Loads the tutorial screen
    public void LoadTutorialScreen()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
