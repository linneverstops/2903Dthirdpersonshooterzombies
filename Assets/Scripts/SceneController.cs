using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private Texture gameOverPic;
	private GUIStyle style = new GUIStyle();
	public List<GameObject> enemy_list;
	private List<Vector3> spawnPositions;
	Animator anim;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		style.fontSize = 25;
		style.normal.textColor = Color.green;
		anim = GameObject.Find ("Player").GetComponent<Animator> ();
		this.enemy_list = new List<GameObject> ();
		this.spawnPositions = new List<Vector3> ();
		int x = -20;
		for (int i = -20; i < 20; i += 10) {
			GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			enemy_list.Add (enemy);
			enemy.transform.position = new Vector3 (x, 0, i);
			float angle = Random.Range (0, 360);
			enemy.transform.Rotate (0, angle, 0);
		}
		x = 20;
		for (int i = -20; i < 20; i += 10) {
			GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			enemy_list.Add (enemy);
			enemy.transform.position = new Vector3 (x, 0, i);
			float angle = Random.Range (0, 360);
			enemy.transform.Rotate (0, angle, 0);
		}
		int z = -20;
		for (int j = -20; j < 20; j+= 10) {
			GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			enemy_list.Add (enemy);
			enemy.transform.position = new Vector3 (j, 0, z);
			float angle = Random.Range (0, 360);
			enemy.transform.Rotate (0, angle, 0);
		}
		z = 20;
		for (int j = -20; j < 20; j += 10) {
			GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			enemy_list.Add (enemy);
			enemy.transform.position = new Vector3 (j, 0, z);
			float angle = Random.Range (0, 360);
			enemy.transform.Rotate (0, angle, 0);
		}
	}

	void Update() {
		if (enemy_list.Count <= 0) {
			anim.SetBool ("Gameover", true);
		}
	}

	void OnGUI() {
		if (enemy_list.Count <= 0) {
			GUI.Label (new Rect (Screen.width/2 - 450, Screen.height/2 - 300, 200, 200), 
				("Congratulations! You have saved Earth from the Zombie Apocalypse"),
				style);
			GUI.DrawTexture (new Rect (50, 140, 400, 250), gameOverPic);
		}
	}

	public void Restart() {
		Application.LoadLevel ("SceneZombie");
	}

	public void GameOver() {
		Application.Quit();
	}
}
