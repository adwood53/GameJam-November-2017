using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour {

	public bool Success = false;

	void OnTriggerEnter (Collider col){
		Debug.Log ("Name: " + col.tag);
		if (col.gameObject.tag == "Player") {
			Success = true;
		}
	}

}
