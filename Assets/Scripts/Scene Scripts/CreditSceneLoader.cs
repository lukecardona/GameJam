using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneLoader : MonoBehaviour
{
    public void LoadCreditScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
