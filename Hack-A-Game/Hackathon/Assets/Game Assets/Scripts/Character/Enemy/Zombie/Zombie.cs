using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

    public new void Start() {
        base.Start();

        this.isAttacking = false;
        this.isWalking = false;
        this.animator = this.GetComponent<Animator>();

        this.changeState(new IdleState());
    }

    public override void Update() {
        if (!this.IsDead && this.isEnabled) {
            this.currentState.execute();
        }
        this.setAnimValues();
    }

    public override void hit() {
        throw new NotImplementedException();
    }
}
