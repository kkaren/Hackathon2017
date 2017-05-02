using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    protected float lifeSpawn;
    protected float speed;
    protected Rigidbody2D rigidbody2d;
    protected float damage;
    protected bool isPassThrough;

    public virtual void init(float lifeSpawn, float speed, float spread, float damage, bool isPassThrough) {
        float randomNumberZ = UnityEngine.Random.Range(-spread, spread);
        this.transform.Rotate(0, 0, randomNumberZ);

        this.isPassThrough = isPassThrough;
        this.damage = damage;
        this.lifeSpawn = lifeSpawn;
        this.speed = speed;
        this.rigidbody2d = GetComponent<Rigidbody2D>();

        this.rigidbody2d.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(this.gameObject, lifeSpawn + UnityEngine.Random.Range(-0.1f, 0.1f));
    }

    public void destroyBullet() {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Walls") {
            this.destroyBullet();
        }

        if (other.gameObject.tag == "Enemy") {
            StartCoroutine(other.GetComponent<Enemy>().takeDamage(other, this.damage));
            if (!isPassThrough) {
                this.destroyBullet();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        this.OnTriggerEnter2D(other);
    }
}
