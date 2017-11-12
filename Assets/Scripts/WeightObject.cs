using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightObject : MonoBehaviour {

	[SerializeField] private int weight = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	public int getWeight(){
		return weight;
	}
}
