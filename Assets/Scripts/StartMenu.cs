using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button startButton;

	// Use this for initialization

	void Start() {

		Button btn = startButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

	}

	void TaskOnClick () {

		SceneManager.LoadScene("Menu");
		Debug.Log ("WHY");

	}

	// Update is called once per frame
	void Update () {

	}
}