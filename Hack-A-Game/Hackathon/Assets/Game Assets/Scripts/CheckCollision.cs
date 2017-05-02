using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {

    public void Awake() {

        if (GetComponent<Collider2D>().IsTouchingLayers(this.gameObject.layer)) {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Walls") {

        }
    }
}
