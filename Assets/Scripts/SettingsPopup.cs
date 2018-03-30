using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsPopup : MonoBehaviour {
	[SerializeField] private Slider speedSlider;
	
	void Start() {
		speedSlider.value = PlayerPrefs.GetFloat("value", 1);
	}

	public void Open() {
		gameObject.SetActive(true);
	}
	public void Close() {
		gameObject.SetActive(false);
	}

	public void OnSubmitName(string name) {
		Debug.Log(name);
	}
	
	public void OnSpeedValue(float value) {
		Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, value);
		PlayerPrefs.SetFloat("value", value);
	}
}
