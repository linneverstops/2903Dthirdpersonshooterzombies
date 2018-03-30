using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UItrigger : MonoBehaviour {

	public Text welcome;
	public GameObject welcomeCanvas;
	public float fadeSpeed = 10.0f;

	private bool _entrance;
	private bool _active;


	

	void Awake (){

		welcome = welcomeCanvas.GetComponentInChildren<Text>();

	}

	// Use this for initialization
	void Start () {

		welcome.color = Color.clear;

		_entrance = false;
		_active = true;

	}

	void Update (){

		ColorChange();

	}
	void OnTriggerEnter(Collider other) {

		_entrance = true;

	}

	void OnTriggerExit(Collider other) {

		_entrance = false;
		_active = false;

	}

	void ColorChange(){

		if(_entrance && _active){
			welcome.color = Color.Lerp(welcome.color, Color.red, fadeSpeed*Time.deltaTime);

		}

		if(!_entrance){
			welcome.color = Color.Lerp(welcome.color, Color.clear, fadeSpeed*Time.deltaTime);
		}
	}
}