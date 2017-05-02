using UnityEngine;
using System.Collections;
using System;

public class WalkingState : IEnemyState {
    private Zombie enemy;

    private float idleTimer = 0;
    private float idleDuration = 5;
    private float dirrection;

    public void enter(Enemy enemy) {
        this.enemy = (Zombie) enemy;
        this.dirrection = UnityEngine.Random.Range(0, 2.0f * Mathf.PI) * Mathf.Rad2Deg + 90;
    }

    public void execute() {
        if (enemy.getTarget() == null && idleTimer >= idleDuration) {
            this.idleTimer = 0;
            enemy.changeState(new IdleState());
        }
        if (enemy.getTarget() != null){
            this.idleTimer = 0;
            enemy.changeState(new AttackState());
        } else {
            this.randomWalk();
        }
    }

    public void exit() {
    }

    public void OnTriggerEnter(Collider2D other) {
    }

    private void randomWalk() {
        this.enemy.randomWalk(this.dirrection);

        this.idleTimer += Time.deltaTime;
    }
}