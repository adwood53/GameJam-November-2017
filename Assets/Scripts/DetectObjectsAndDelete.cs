using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectsAndDelete : MonoBehaviour {

	[SerializeField] private int limit = 1;
    [SerializeField] private Animation anim;
	public bool Success = false;
	private int total = 0;

	void OnTriggerEnter (Collider col){
		//Debug.Log ("Name: " + col.tag);
		if (col.gameObject.tag == "Clone") {
			col.gameObject.SetActive (false);
			total++;
			Debug.Log ("Dead Total: " + total);
		}
	}

	// Update is called once per frame
	void Update () {
		if (total >= limit) {
			Success = true;
            anim.Stop();
        } else {
			Success = false;
		}
	}
}
