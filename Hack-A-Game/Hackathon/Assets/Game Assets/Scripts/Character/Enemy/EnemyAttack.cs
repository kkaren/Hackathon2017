using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            StartCoroutine(collision.GetComponent<Player>().takeDamage(collision, GetComponentInParent<Enemy>().getDamage()));
        }
    }
}
