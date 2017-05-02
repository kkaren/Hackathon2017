using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    [SerializeField] protected List<string> damageSources;
    [SerializeField] protected float health;
    protected Rigidbody2D rb;

    protected bool IsDead { get { return this.health <= 0; } }

    public abstract IEnumerator takeDamage(Collider2D other, float damage);
    public abstract void Update();
    public abstract void hit();

    public void Start() {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.checkDeath();
    }

    public float getHealth() {
        return this.health;
    }

    public void checkDeath() {
        if (this.IsDead) {
            destroyObject();
        }
    }

    public void destroyObject() {
        Destroy(this.gameObject);
    }
}
