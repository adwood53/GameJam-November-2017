using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

	public GameObject objectDetected;
	public bool InRangeOfItem;
	public bool PickupAvailable;


	void start() {
	 
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("object in me " + other);
		InRangeOfItem = true;
		PickupAvailable = true;
		ScanForItems();
	}

		void OnTriggerExit (Collider other) {
		Debug.Log ("object not in me" + other);
		InRangeOfItem = false;
		PickupAvailable = false;
	}
		
	void ScanForItems () {

	} 

	void update() {
		
	}
}
