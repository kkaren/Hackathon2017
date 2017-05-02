using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour {
	GameObject[] pauseObjects;
	bool paused = false;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("Pause");
		hidePause ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void hidePause() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
	}

	public void Pause() {
		if (!paused) {
            Time.timeScale = 0;
			paused = true;
			showPaused ();
		} else {
			paused = false;
			hidePause ();
		}
	}

	private void showPaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive (true);
		}
	}
	public void quitPause() {
        Time.timeScale = 1;

        hidePause();
		paused = false;
	}

	public void restartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
		
}
