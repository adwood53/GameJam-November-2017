using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour {

	[SerializeField] private int limit = 1;
	[SerializeField] private Transform button;
	private Transform startPos;
	private Transform pushedPos;
	public bool Success = false;
	private int total = 0;


	// Use this for initialization
	void Start () {
		startPos = button;
	}

	void OnTriggerEnter (Collider col){
		//Debug.Log ("Name: " + col.tag);
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Clone") {
			total += col.gameObject.GetComponent<WeightObject> ().getWeight ();
			Debug.Log ("Total: " + total);
		}
	}

	void OnTriggerExit(Collider col){
		//Debug.Log ("Name: " + col.tag);
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Clone") {
			total -= col.gameObject.GetComponent<WeightObject> ().getWeight ();
			Debug.Log ("Total: " + total);
		}
	}

	// Update is called once per frame
	void Update () {
		if (total >= limit) {
			Success = true;
			button.localPosition = new Vector3(button.localPosition.x, button.localPosition.y, 0);
		} else {
			button.localPosition = new Vector3(button.localPosition.x, button.localPosition.y, 0.084f);
			Success = false;
		}
	}
}
