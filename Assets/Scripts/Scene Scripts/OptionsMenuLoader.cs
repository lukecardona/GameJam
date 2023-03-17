using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionsMenuLoader : MonoBehaviour
{
    // Loads the options menu
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
