using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class FlameThrower : RangedWeapon {
    private bool isFiring = false;
    private GameObject bullet;
    [SerializeField] protected Transform startPoint;
    [SerializeField] protected Transform endPoint;

    public override void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
            this.canFire = true;
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1")) {
            this.canFire = false;
            this.isFiring = false;
            this.bullet.GetComponent<Animator>().SetBool("isFiring", false);
        }

        if (this.canFire) {
            this.fireBullet();
        }
    }

    public override void fireBullet() {
        this.lastShot = (1.0f / this.fireRate) / this.shootPoints.Count;
        this.ammo--;

        if (!this.isFiring) {
            this.bullet = Instantiate(bulletPrefab, this.shootPoints[this.currentShootPoint].transform.position, this.shootPoints[this.currentShootPoint].rotation, this.transform);
            this.bullet.GetComponent<FlamethowerBullet>().init(this.shootPoints[0].transform, this.range, this.bulletSpeed, this.spread, this.damage, this.isPassThrough, this.startPoint, this.endPoint);

            this.isFiring = true;
        }
    }
}
