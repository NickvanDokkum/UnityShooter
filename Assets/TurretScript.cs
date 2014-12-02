using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour {

	public static TurretScript singleton;
	
	public GameObject myProjectile;
	public float reloadTime = 0.1f;
	public Transform spawnPos;
	
	public Transform myTarget = null;

	public List<Transform> blueEnemyList = new List<Transform>();
	public List<Transform> redEnemyList = new List<Transform>();

	private Quaternion desiredRotation;

	void Awake () {
		singleton = this;
	}

	void Update () {
		if(Input.GetKeyDown("space")){
			if(!Globals.focusTank){
				Globals.focusTank = true;
			}
			else if (Globals.focusTank) {
				Globals.focusTank = false;
			}
			Debug.Log(Globals.focusTank);
		}
		if(Globals.focusTank){
			if(blueEnemyList.Count > 0)
			{
				myTarget = blueEnemyList[0].transform;
			}
			else if(redEnemyList.Count > 0)
			{
				myTarget = redEnemyList[0].transform;
			}
			else
			{
				myTarget = null;
			}
		}
		else {
			if(redEnemyList.Count > 0)
			{
				myTarget = redEnemyList[0].transform;
			}
			else if(blueEnemyList.Count > 0)
			{
				myTarget = blueEnemyList[0].transform;
			}
			else
			{
				myTarget = null;
			}
		}

		if (myTarget!=null)
		{
			transform.LookAt(myTarget);   

			if(reloadTime == 0 || reloadTime < 0)
			{
				FireProjectile (); 
				reloadTime = 1;
			}
			else
			{
				reloadTime -= Time.deltaTime;
			}
		}
		
	}
	
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "Enemy1")
		{
			redEnemyList.Add (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			blueEnemyList.Add (other.gameObject.transform);
		}
	}
	
	void OnTriggerExit(Collider other){
		
		if (other.gameObject.transform == myTarget)
		{
			myTarget = null;   
		}
		if (other.gameObject.tag == "Enemy1")
		{
			redEnemyList.Remove (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			blueEnemyList.Remove (other.gameObject.transform);
		}
	}
	
	
	void FireProjectile(){

		Instantiate (myProjectile, spawnPos.transform.position, this.transform.rotation);
	}
}