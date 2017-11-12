using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClone : MonoBehaviour {

	public Transform SpawnLocation;
	public GameObject[] Prefab;
	[SerializeField] private int spawnLimit = 3;
	private GameObject Clone;
	private int spawnCounter = 0;


	void Update () {
		

		if(Input.GetKeyDown(KeyCode.Space)){
			Spawn ();
			spawnCounter++;
		}
	}

	void Spawn(){
		if (spawnCounter < spawnLimit) {
			Clone = Instantiate (Prefab [Random.Range (0, Prefab.Length)], SpawnLocation.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
		}
	}

}

