using UnityEngine;
using System.Collections;
using System;

public class AttackState : IEnemyState {
    private Zombie enemy;

    public void enter(Enemy enemy) {
        this.enemy = (Zombie) enemy;
    }

    public void execute() {
        if (enemy.getTarget() == null) {
            enemy.changeState(new IdleState());
        } else {
            this.attack();
        }
    }

    public void exit() {
    }

    public void OnTriggerEnter(Collider2D other) {
    }

    private void attack() {
        if (this.enemy.CanAttack) {
            this.enemy.attack();
        } else {
            this.enemy.walkNormalToTarget();
        }
    }
}