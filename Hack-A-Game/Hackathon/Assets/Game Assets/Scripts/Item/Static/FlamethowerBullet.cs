using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethowerBullet : Bullet {
    private Transform shootPoint;
    private float spread;
    private Vector3 start;
    private Vector3 end;
    private Transform originalEnd;

    public void init(Transform shootPoint, float lifeSpawn, float speed, float spread, float damage, bool isPassThrough, Transform start, Transform end) {
        this.isPassThrough = isPassThrough;
        this.damage = damage;
        this.spread = spread;
        float randomNumberZ = Random.Range(-spread, spread);
        this.transform.Rotate(0, 0, randomNumberZ);
        this.GetComponent<Animator>().SetBool("isFiring", true);
        this.shootPoint = shootPoint;

        this.start = start.position;
        this.end = end.position;
        this.originalEnd = end;
        this.calculatePositionAndScale();
    }

    public void FixedUpdate() {
        this.end = this.originalEnd.position;

        RaycastHit2D hit = Physics2D.Raycast(this.shootPoint.position, this.transform.up, Vector3.Distance(this.shootPoint.position, this.originalEnd.position), 1 << LayerMask.NameToLayer("Walls"));
        if (hit.collider != null) {
            Debug.Log(hit.distance);
            this.end = hit.point;
        }
        calculatePositionAndScale();

    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            StartCoroutine(other.GetComponent<Enemy>().takeDamage(other, this.damage));
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        this.OnTriggerEnter2D(other);
    }

    void calculatePositionAndScale() {
        Vector3 centerPos = (this.shootPoint.position + end) / 2f;
        this.transform.position = centerPos;

        float scaleY = Vector3.Distance(this.shootPoint.position, end) / 5;
        this.transform.localScale = new Vector3(0.2f, scaleY, 0.5f);
    }
}