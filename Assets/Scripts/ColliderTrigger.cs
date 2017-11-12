using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

	[SerializeField] private GameObject objectDetected;
	public bool InRangeOfItem = false;
	public bool PickupAvailable = false;
	[SerializeField] private bool carrying = false;
	[SerializeField] private Transform pickUpPoint;

	void start() {
	 
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("object in me " + other);
		InRangeOfItem = true;
		if (other.gameObject.tag == "Clone") {
			PickupAvailable = true;
			objectDetected = other.gameObject;
		}
	}

	void OnTriggerExit (Collider other) {
		Debug.Log ("object not in me" + other);
		InRangeOfItem = false;
		PickupAvailable = false;
		objectDetected = null;
	}

	void Update() {
		if (PickupAvailable) {
			if (Input.GetKeyDown (KeyCode.E)) {
				objectDetected.transform.position = pickUpPoint.position;
				objectDetected.transform.SetParent (pickUpPoint);
				objectDetected.GetComponent<Rigidbody> ().isKinematic = true;
				objectDetected.GetComponent<CapsuleCollider> ().enabled = false;
			}
		}
	}
}
