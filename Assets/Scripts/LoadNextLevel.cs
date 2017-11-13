using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {

	[SerializeField] public string newLevel = "Level1";

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter (Collider col){
		Debug.Log ("Name: " + col.tag);
		if (col.gameObject.tag == "Player" && col.gameObject.tag != "Level") {
			Debug.Log ("Loading: " + newLevel);
			Application.LoadLevel (newLevel);
		}
	}
}
