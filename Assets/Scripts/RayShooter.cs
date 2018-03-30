﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;



public class RayShooter : MonoBehaviour {
	private Camera _camera;

	public Texture reticle;

	void Start() {
		_camera = GetComponent<Camera>();
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}

	void OnGUI() {
		int size = 50;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		//GUI.Label(new Rect(posX, posY, size, size), "*");
		GUI.DrawTexture(new Rect(posX, posY, size, size), reticle);
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
					Messenger.Broadcast(GameEvent.ENEMY_HIT);
				} else {if(hitObject.tag != "UITrigger")
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}