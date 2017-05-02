using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState {
    private Zombie enemy;

    private float idleTimer;
    private float idleDuration = 5;

    public void enter(Enemy enemy) {
        this.enemy = (Zombie) enemy;
    }

    public void execute() {
        if (enemy.getTarget() == null && idleTimer >= idleDuration) {
            this.idleTimer = 0;
            enemy.changeState(new WalkingState());
        }else if(enemy.getTarget() != null) {
            this.idleTimer = 0;
            enemy.changeState(new AttackState());
        } else {
            this.idle();
        }
    }

    public void exit() {
    }

    public void OnTriggerEnter(Collider2D other) {
    }

    private void idle() {
        this.enemy.stopWalking();

        idleTimer += Time.deltaTime;

    }
}