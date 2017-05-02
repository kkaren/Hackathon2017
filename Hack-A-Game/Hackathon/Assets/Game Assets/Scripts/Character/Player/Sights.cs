using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sights : MonoBehaviour {
	private Vector3 position;

	// Use this for initialization
	void Start () {
		this.position = Vector3.zero;
        this.hideCursor();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v3 = Input.mousePosition;
		this.position = Camera.main.ScreenToWorldPoint(v3);
        this.position.z = -5;
        this.transform.SetPositionAndRotation(this.position, this.transform.rotation);
	}

	public Vector3 getPosition(){
		return this.position;
	}

	public Quaternion getRotationFromPoint(float x, float y){
        float angle = Mathf.Atan2(this.transform.position.y - y, this.transform.position.x - x) * Mathf.Rad2Deg - 90;
        return Quaternion.Euler(0, 0, angle);
    }

    public void showCursor() {
        Cursor.visible = true;
    }

    public void hideCursor() {
        Cursor.visible = false;
    }
}
