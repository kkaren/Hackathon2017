using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item {
    [SerializeField, Range(0, 10)]
    protected float range;
    [SerializeField, Range(0, 10)]
    protected float fireRate;
    [SerializeField, Range(0, 200)]
    protected float damage;
    [SerializeField, Range(0, 2)]
    protected int wieldType;
    [SerializeField]
    protected bool owned;

    public abstract void Start();
    public abstract void Update();

    //0 for melee, 1 for 1h, 2 for 2h
    public int getWieldType() {
        return this.wieldType;
    }

    public bool isOwned() {
        return this.owned;
    }
}
