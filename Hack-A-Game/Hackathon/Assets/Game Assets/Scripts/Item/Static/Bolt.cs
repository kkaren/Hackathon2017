using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Bullet {
    private Vector3 start;
    private Vector3 end;

    public void init(float lifeSpawn, float speed, float spread, float damage, bool isPassThrough, Transform start, Transform end) {
        float randomNumberZ = UnityEngine.Random.Range(-spread, spread);
        this.transform.Rotate(0, 0, randomNumberZ);

        this.isPassThrough = isPassThrough;
        this.damage = damage;
        this.start = start.position;
        this.end = end.position;
        this.calculatePositionAndScale();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Walls") {
            RaycastHit2D hit = Physics2D.Raycast(this.start, this.transform.up, Vector3.Distance(start, end), 1 << LayerMask.NameToLayer("Walls"));
            if (hit.collider != null) {
                Debug.Log(hit.distance);
                this.end = hit.point;
                calculatePositionAndScale();
            }
        }

        if (other.gameObject.tag == "Enemy") {
            StartCoroutine(other.GetComponent<Enemy>().takeDamage(other, this.damage));
        }
    }

    void OnTriggerStay2D(Collider2D other) {
    }

    void calculatePositionAndScale() {
        Vector3 centerPos = (start + end) / 2f;
        this.transform.position = centerPos;

        float scaleY = Vector3.Distance(start, end)/5;
        this.transform.localScale = new Vector3(0.2f, scaleY, 0.5f);
    }
}