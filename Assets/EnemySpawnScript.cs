using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public GameObject Enemy;
	private float timer = 0.5f;

	void Update () {
		if (timer < 0){
			Instantiate (Enemy, this.transform.position, this.transform.rotation);
			timer = 0.5f;
		}
		else {
			timer -= Time.deltaTime;
		}
	}
}
