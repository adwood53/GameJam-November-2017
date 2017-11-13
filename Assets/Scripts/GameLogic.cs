using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

	[SerializeField] public Transform[] objects;
	[SerializeField] public Transform hinge;
	private bool success = false;
	private bool open = false; 
	private bool opened = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool temp = true;
		foreach(Transform o in objects){
			if (o.GetComponent<DetectObjects> () != null && temp) {
				temp = o.GetComponent<DetectObjects> ().Success; 
			}
			if (o.GetComponent<InteractZone> () != null && temp) {
				temp = o.GetComponent<InteractZone> ().Success; 
			}
			if (o.GetComponent<DetectObjectsAndDelete> () != null && temp) {
				temp = o.GetComponent<DetectObjectsAndDelete> ().Success;
			}
		}
		if (temp) {
			success = true;
		}
		if (success) {
			open = true;
		} else {
			open = false;
		}
		if (open && !opened) {
			transform.RotateAround (hinge.position, Vector3.up, -150f);
			opened = true;
		}
	}
}
