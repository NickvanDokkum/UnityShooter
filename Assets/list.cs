using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class list : MonoBehaviour {

	public static list singleton;

	public List<Transform> blueEnemyList = new List<Transform>();
	public List<Transform> redEnemyList = new List<Transform>();



	void Awake()
	{
		singleton = this;
	}

	void Update () {

	}
	

}
