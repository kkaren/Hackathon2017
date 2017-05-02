using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            GetComponentInParent<Enemy>().CanAttack = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision) {
        this.OnTriggerEnter2D(collision);
    }
}
