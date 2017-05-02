using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltGun : RangedWeapon {
    [SerializeField] protected Transform startPoint;
    [SerializeField] protected Transform endPoint;

    override
    public void fireBullet() {
        this.lastShot = (1.0f / this.fireRate) / this.shootPoints.Count;
        this.ammo--;
        GameObject bullet = Instantiate(this.bulletPrefab, this.shootPoints[this.currentShootPoint].transform.position, this.shootPoints[this.currentShootPoint].rotation);
        bullet.GetComponent<Bolt>().init(this.range, this.bulletSpeed, this.spread, this.damage, this.isPassThrough, this.startPoint.transform, this.endPoint.transform);
        this.currentShootPoint++;
        this.currentShootPoint %= this.shootPoints.Count;
    }
}
