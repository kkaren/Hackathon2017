using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : Character {
    [SerializeField] private UnityEngine.Object sights;
    [SerializeField] private Animator upperBody;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject deathScreen;

    private int money;
    private WeaponList weaponList;
    private Weapon currentWeapon;

    public new void Start() {
        base.Start();
        this.transform.position = new Vector3(this.startPoint.position.x, this.startPoint.position.y, this.transform.position.z);

        this.weaponList = this.GetComponentInChildren<WeaponList>();
        this.getDefaultWeapon();
    }

    public override void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Fire2")) {
            this.getNextWeapon();
        }
    }

    public override void hit() {
        throw new NotImplementedException();
    }

    public override IEnumerator takeDamage(Collider2D other, float damage) {
        this.health -= damage;

        if (IsDead) {
            this.died();
            yield return null;
        }
    }

    public void addMoney(int money) {
        this.money += money;
    }

    public void setWeaponAnimation() {
        if (currentWeapon.getWieldType() == 0) {
            this.upperBody.SetBool("isDW", true);
            this.upperBody.SetBool("is1h", false);
            this.upperBody.SetBool("is2h", false);
        } else if(currentWeapon.getWieldType() == 1) {
            this.upperBody.SetBool("isDW", false);
            this.upperBody.SetBool("is1h", true);
            this.upperBody.SetBool("is2h", false);
        } else {
            this.upperBody.SetBool("isDW", false);
            this.upperBody.SetBool("is1h", false);
            this.upperBody.SetBool("is2h", true);
        }
    }

    public void getNextWeapon() {
        this.currentWeapon = this.weaponList.getNextWeapon();
        this.setWeaponAnimation();
    }

    public void getDefaultWeapon() {
        this.currentWeapon = this.weaponList.getDefaultWeapon();
        this.setWeaponAnimation();
    }

    public void died() {
        this.deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void resetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
