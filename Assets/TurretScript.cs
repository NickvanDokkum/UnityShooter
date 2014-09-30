using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	
	
	public GameObject myProjectile;
	public float reloadTime = 0.1f;
	public Transform spawnPos;
	
	public Transform myTarget = null;

	private Quaternion desiredRotation;

	void Update () {

		if(list.singleton.blueEnemyList.Count > 0)
		{
			myTarget = list.singleton.blueEnemyList[0].transform;
		}
		else if(list.singleton.redEnemyList.Count > 0)
		{
			myTarget = list.singleton.redEnemyList[0].transform;
		}
		else
		{
			myTarget = null;
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
			list.singleton.redEnemyList.Add (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			list.singleton.blueEnemyList.Add (other.gameObject.transform);
		}
	}
	
	void OnTriggerExit(Collider other){
		
		if (other.gameObject.transform == myTarget)
		{
			myTarget = null;   
		}
		if (other.gameObject.tag == "Enemy1")
		{
			list.singleton.redEnemyList.Remove (other.gameObject.transform);
		}
		if (other.gameObject.tag == "Enemy2")
		{
			list.singleton.blueEnemyList.Remove (other.gameObject.transform);
		}
	}
	
	
	void FireProjectile(){

		Instantiate (myProjectile, spawnPos.transform.position, this.transform.rotation);
	}
}