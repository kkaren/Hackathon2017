﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {
    [SerializeField]
    protected Sprite icon;
    [SerializeField]
    protected int price;
}
