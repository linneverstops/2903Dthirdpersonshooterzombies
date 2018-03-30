using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	Animator anim;

	void Start(){

		anim = GetComponent<Animator>();
	}


	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		this.transform.Rotate(-75, 0, 0);
		anim.SetInteger("zombieToState", 2);
		SceneController controller = GameObject.Find ("Controller").GetComponent<SceneController> ();
		controller.enemy_list.Remove (this.gameObject);
		yield return new WaitForSeconds(3f);
		
		Destroy(this.gameObject);
	}
}
