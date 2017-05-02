using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour{
    [SerializeField] private List<Weapon> weaponList;
    private List<Weapon> availableWeapons;
    private int currentWeapon;

    private void Awake() {
        this.currentWeapon = 0;
        this.availableWeapons = this.getAvailableWeapons();
    }

    public List<Weapon> getAvailableWeapons() {
        List<Weapon> availableWeapons = new List<Weapon>();

        foreach(Weapon weapon in this.weaponList) {
            if (weapon.isOwned()) {
                availableWeapons.Add(weapon);
            }
        }
        return availableWeapons;
    }

    public Weapon getNextWeapon() {
        this.availableWeapons[this.currentWeapon].gameObject.SetActive(false);
        this.currentWeapon++;
        this.currentWeapon %= this.availableWeapons.Count;
        this.availableWeapons[this.currentWeapon].gameObject.SetActive(true);
        return this.availableWeapons[this.currentWeapon];
    }

    public Weapon getDefaultWeapon() {
        this.availableWeapons[0].gameObject.SetActive(true);
        return this.availableWeapons[0];
    }
}
