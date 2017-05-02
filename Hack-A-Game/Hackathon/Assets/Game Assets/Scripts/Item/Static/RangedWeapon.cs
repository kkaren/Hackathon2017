using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RangedWeapon : Weapon {
    [SerializeField] protected bool isPassThrough;
    [SerializeField, Range(0, 10)] protected float spread;
    [SerializeField, Range(0, 20)] protected int bulletSpeed;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected List<Transform> shootPoints = new List<Transform>();
    protected int ammo;
    protected bool canFire;
    protected float lastShot;
    protected int currentShootPoint;

    public override void Start() {
        this.ammo = 500;
        this.canFire = false;
        this.lastShot = 0;
        this.currentShootPoint = 0;
    }

    public override void Update() {
        if (Input.touchCount == 1) {
            this.canFire = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            this.canFire = false;
        }

        this.lastShot -= Time.deltaTime;
        if (this.canFire && this.lastShot < 0 && this.ammo > 0) {
            this.fireBullet();
        }
    }

    public virtual void fireBullet() {
        this.lastShot = (1.0f/this.fireRate) / this.shootPoints.Count;
        this.ammo--;
        this.currentShootPoint++;
        this.currentShootPoint %= this.shootPoints.Count; 
    }

    public void addAmmo(int ammo) {
        this.ammo += ammo;
    }

    public void fire() {
        Debug.Log("lol");
        if (this.lastShot < 0 && this.ammo > 0) {
            this.fireBullet();
        }
    }
}
