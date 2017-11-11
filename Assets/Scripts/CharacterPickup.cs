using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

public class CharacterPickup : MonoBehaviour {

	public bool IsPickedUp;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
			
		if (IsPickedUp == false) {
			GetComponent<ThirdPersonCharacter> ().enabled = true;
			GetComponent<AICharacterControl> ().enabled = true;
			GetComponent<NavMeshAgent> ().enabled = true;
		}
		else 
		{
			GetComponent<ThirdPersonCharacter> ().enabled = false;
			GetComponent<AICharacterControl> ().enabled = false;
			GetComponent<NavMeshAgent> ().enabled = false;
		}
	}
}

