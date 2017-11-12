using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClone : MonoBehaviour {

	public Transform SpawnLocation;
	public GameObject[] Prefab;
	[SerializeField] private int spawnLimit = 3;
	private GameObject Clone;
	private int spawnCounter = 0;
	[SerializeField] bool PlayerNear;
		
	void Update () {
		

		if(Input.GetKeyDown(KeyCode.F)) {
			if (PlayerNear  == true) {
				Spawn ();
				spawnCounter++;
			}
		}
	}

	void Spawn(){
		if (spawnCounter < spawnLimit) {
			Clone = Instantiate (Prefab [Random.Range (0, Prefab.Length)], SpawnLocation.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
		}
	}

	void OnTriggerEnter (Collider Col) {

		if (Col.gameObject.name == "Player") {
			PlayerNear = true;
			Debug.Log (Col.gameObject.name);
		}
	}
	
	void OnTriggerExit(Collider ColExit) {

		if (ColExit.gameObject.name == "Player") {
			PlayerNear = false;
			Debug.Log ("asf");
		}
		}
}

