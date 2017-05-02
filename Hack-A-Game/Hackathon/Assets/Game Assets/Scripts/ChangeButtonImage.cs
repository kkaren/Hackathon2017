using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour {
    [SerializeField] private UnityEngine.UI.Image horizontal;
    [SerializeField] private UnityEngine.UI.Image vertical;
    private bool isHorizontal = true;

    public bool IsHorizontal {
        get {
            return isHorizontal;
        }

        set {
            isHorizontal = value;
        }
    }

    public void changeOrientation() {
        if (this.IsHorizontal) {
            this.IsHorizontal = false;
            this.vertical.gameObject.SetActive(true);
            this.horizontal.gameObject.SetActive(false);
        } else {
            this.IsHorizontal = true;
            this.vertical.gameObject.SetActive(false);
            this.horizontal.gameObject.SetActive(true);
        }
    }
}
