using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
	int progress = 0;
	private Slider slider;

	private void Start() {
		slider = GetComponent<Slider>();
		slider.value = slider.maxValue; //Get Max Bar
		progress = (int)slider.value; //Get Max Value
	}

	public void AddToSlider() {
		progress++;
		slider.value = progress;
	}

	public void RemoveFromSlider() {
		progress--;
		slider.value = progress;
	}
}
