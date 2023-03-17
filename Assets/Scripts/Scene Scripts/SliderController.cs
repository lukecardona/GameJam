using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
}
