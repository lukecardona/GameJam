using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;

    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Checks if there is a saved value for muted
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    // Sets mute button off or on
    public void onButtonClick()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    // Loads players last mute setting
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    // Saves players mute setting
    private void Save()
    {
        if (muted == true)
        {
            PlayerPrefs.SetInt("muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        
    }

    // Updates the mute button icon
    private void UpdateButtonIcon()
    {
        if (muted == true)
        {
            soundOn.gameObject.SetActive(false);
            soundOff.gameObject.SetActive(true);
        }
        else
        {
            soundOn.gameObject.SetActive(true);
            soundOff.gameObject.SetActive(false);
        }
    }
}
