using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Shotgun : RangedWeapon {
    [SerializeField] private float bulletsPerShot;

    public override void fireBullet() {
        this.lastShot = (1.0f / this.fireRate) / this.shootPoints.Count;
        for(int i = 0; i < this.bulletsPerShot; i++) {
            this.shootBullet();
        }
    }

    public void shootBullet() {
        this.ammo--;
        float pos = UnityEngine.Random.Range(-0.05f, 0.05f);
        GameObject bullet = Instantiate(bulletPrefab, this.shootPoints[this.currentShootPoint].transform.position + new Vector3(pos, pos, 0), this.shootPoints[this.currentShootPoint].rotation);
        bullet.GetComponent<Bullet>().init(this.range, this.bulletSpeed, this.spread, this.damage, this.isPassThrough);
    }
}
