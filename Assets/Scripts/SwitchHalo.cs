using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHalo : MonoBehaviour {

	[SerializeField] public GameObject halo;

	// Use this for initialization
	void Start () {
		halo.SetActive (false);
	}
	
	public void SetOn(){
		halo.SetActive (true);
	}

	public void SetOff(){
		halo.SetActive (false);
	}
}
