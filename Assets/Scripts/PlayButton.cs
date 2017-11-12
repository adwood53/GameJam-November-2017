using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public Button playButton;

	// Use this for initialization

	void Start() {

		Button btn = playButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);

	}

	void TaskOnClick () {

		SceneManager.LoadScene("Level1");
		Debug.Log ("WHY");

	}

	// Update is called once per frame
	void Update () {

	}
}

