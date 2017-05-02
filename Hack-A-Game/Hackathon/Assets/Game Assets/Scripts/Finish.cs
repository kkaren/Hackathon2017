using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            if(SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCount - 1) {
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision) {
        this.OnTriggerEnter2D(collision);
    }
}
