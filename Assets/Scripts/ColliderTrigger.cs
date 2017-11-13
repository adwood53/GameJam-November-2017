using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColliderTrigger : MonoBehaviour {

	[SerializeField] private GameObject objectDetected;
	public bool InRangeOfItem = false;
	public bool PickupAvailable = false;
	[SerializeField] private bool carrying = false;
	private bool lockControl = false;
	[SerializeField] private Transform pickUpPoint;
	private GameObject objectCarried = null;

	void start() {
	 
	}

	void OnTriggerEnter (Collider other) {
		//Debug.Log ("object in me " + other);
		InRangeOfItem = true;
		if (other.gameObject.tag == "Clone") {
			PickupAvailable = true;
			objectDetected = other.gameObject;
			other.gameObject.GetComponent<SwitchHalo> ().SetOn ();
		}
	}

	void OnTriggerExit (Collider other) {
		//Debug.Log ("object not in me" + other);
		InRangeOfItem = false;
		PickupAvailable = false;
		objectDetected = null;
		if(other.gameObject.GetComponent<SwitchHalo>() != null)
			other.gameObject.GetComponent<SwitchHalo> ().SetOff ();
	}

	void Update() {
		if(pickUpPoint.childCount == 0){
			carrying = false;
		}
		if (Input.GetKeyDown (KeyCode.E) && objectDetected != null) {
			if (PickupAvailable && !carrying) {
				objectDetected.GetComponent<Rigidbody> ().isKinematic = true;
				objectDetected.GetComponent<BoxCollider> ().enabled = false;
				objectDetected.GetComponent<SphereCollider> ().enabled = false;
				objectDetected.transform.SetParent (pickUpPoint);
				objectDetected.transform.localPosition = new Vector3(-0.5f, 0, 0);
				objectDetected.transform.localRotation = Quaternion.Euler(new Vector3(-90,-90,0));
				objectCarried = objectDetected;
				lockControl = false;
			}
			if(carrying){
				pickUpPoint.transform.DetachChildren();
				objectDetected.GetComponent<Rigidbody> ().isKinematic = false;
				objectDetected.GetComponent<BoxCollider> ().enabled = true;
				objectDetected.GetComponent<SphereCollider> ().enabled = true;
				lockControl = false;
			}
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			if(carrying){
				
				objectCarried.GetComponent<Rigidbody> ().isKinematic = false;
				objectCarried.GetComponent<Rigidbody> ().velocity = (transform.forward * 10) + (transform.up * 8);
				objectCarried.GetComponent<BoxCollider> ().enabled = true;
				objectCarried.GetComponent<SphereCollider> ().enabled = true;
				pickUpPoint.transform.DetachChildren();
				lockControl = false;
			}
		}
		if (Input.GetKeyUp (KeyCode.E)) {
			if (!carrying && !lockControl) {
				carrying = true;
				lockControl = true;
			}
			if (carrying && !lockControl) {
				carrying = false;
				lockControl = true;
			}
		}
	}
}
