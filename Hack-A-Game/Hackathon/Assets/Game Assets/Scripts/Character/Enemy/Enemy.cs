using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character {
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject attackPoint;
    [SerializeField] protected GameObject target;

    protected IEnemyState currentState;
    protected Animator animator;
    protected bool isAttacking;
    protected bool isWalking;
    protected bool isEnabled = false;

    public bool CanAttack {
        get {
            return this.isAttacking;
        }

        set {
            this.isAttacking = value;
        }
    }

    public GameObject Target {
        get {
            return target;
        }

        set {
            target = value;
        }
    }

    public override IEnumerator takeDamage(Collider2D other, float damage) {
        this.health -= damage;

        if (IsDead) {
            this.setAnimValues();
            this.stopWalking();
            yield return null;
        }
    }

    //Changes to a different state
    public void changeState(IEnemyState newState) {
        if (this.currentState != null) {
            this.currentState.exit();
        }

        this.currentState = newState;
        this.currentState.enter(this);
    }

    public GameObject getTarget() {
        return this.Target;
    }

    public void setAnimValues() {
        this.animator.SetBool("isAttacking", this.isAttacking);
        this.animator.SetBool("isWalking", this.isWalking);
        this.animator.SetBool("isDead", this.IsDead);
    }

    public void setWalking(float speed) {
        //this.rb.velocity = -this.transform.up * speed;

        this.isAttacking = false;
        this.isWalking = true;

        this.setAnimValues();
        this.animator.SetFloat("speed", speed);
    }

    public void setIdle() {
        this.rb.velocity = Vector2.zero;

        this.isAttacking = false;
        this.isWalking = false;

        this.setAnimValues();
        this.animator.SetFloat("speed", 0);
    }

    public void setAttacking() {
        this.isAttacking = true;
        this.isWalking = false;

        this.setAnimValues();
    }

    public void enable() {
        this.isEnabled = true;
    }

    public void stopWalking() {
        this.setIdle();
    }

    private void walkToTarget(float speed) {
        float angle = Mathf.Atan2(this.Target.transform.position.y - this.transform.position.y, this.Target.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg + 90;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        this.setWalking(speed);
    }

    public void walkSlowlyToTarget() {
        this.walkToTarget(this.speed / 5.0f);
    }

    public void walkNormalToTarget() {
        this.walkToTarget(this.speed);
    }

    public void randomWalk(float angle) {
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        this.setWalking(this.speed / 5.0f);
    }

    public void attack() {
        this.attackPoint.SetActive(true);
        this.setAttacking();
    }

    public void disableAttack() {
        this.CanAttack = false;
        this.attackPoint.SetActive(false);
        this.setAnimValues();
    }

    public float getDamage() {
        return this.damage;
    }
}
