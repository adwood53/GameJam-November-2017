using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClone : MonoBehaviour {

	public int ArraySize = 0;
	public Transform SpawnLocation;
	public GameObject[] Prefab;
	private GameObject Clone;
	private int Counter = 0;


	void Update () {
		

		if(Input.GetKeyDown(KeyCode.Space)){
			Spawn ();
			Counter = Counter + 1;
		}
	}

	void Spawn(){
		if(Counter>= 3){ 
			Counter = 0;
		}
		else
		{
		Clone = Instantiate (Prefab[Counter], SpawnLocation[Counter].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		}
	}

}

