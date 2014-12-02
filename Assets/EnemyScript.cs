using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private float powerLevel;
	private float timer = 0;

	void Start(){
		powerLevel = Random.Range(0, 2);
		if (powerLevel == 0) {
			gameObject.tag = "Enemy1";
		}
		else if (powerLevel == 1){
			gameObject.tag = "Enemy2";
			renderer.material.color = Color.blue;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet")
		{
			if (powerLevel == 0) 
			{
				TurretScript.singleton.redEnemyList.Remove(this.transform);
				Destroy (gameObject);
			}
			else
			{
				TurretScript.singleton.blueEnemyList.Remove(this.transform);
				Destroy (gameObject);
			}
		}
	}

	void Update () {
		if(timer > 5){
			if (powerLevel == 0) 
			{
				TurretScript.singleton.redEnemyList.Remove(this.transform);
				Destroy (gameObject);
			}
			else
			{
				TurretScript.singleton.blueEnemyList.Remove(this.transform);
				Destroy (gameObject);
			}
		}
		else {
			timer += Time.deltaTime;
		}
		if (powerLevel == 0) {
			transform.Translate (Vector3.forward/10);
			transform.Translate (Vector3.right/60);
		}
		else if (powerLevel == 1){
			transform.Translate (Vector3.forward/10);
			transform.Translate (Vector3.left/60);
		}
	}
}
