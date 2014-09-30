using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	private float mySpeed = 1.0f;
	private float myRange = 5.0f;
	
	private float myDist;

	void Start () {

	}

	void Update () {
		transform.Translate (Vector3.forward*mySpeed);
		myDist += Time.deltaTime * mySpeed;
		if (myDist>=myRange)
		{
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy1")
		{
			Destroy(gameObject);
		}
		else if (other.gameObject.tag == "Enemy2"){
			Destroy(gameObject);
		}
	}
}