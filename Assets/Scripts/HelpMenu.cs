using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour {

	public Button helpButton;

	// Use this for initialization

	void Start() {

		Button btn = helpButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

	}

	void TaskOnClick () {

		SceneManager.LoadScene("Help");
		Debug.Log ("WHY");

	}

	// Update is called once per frame
	void Update () {

	}
}