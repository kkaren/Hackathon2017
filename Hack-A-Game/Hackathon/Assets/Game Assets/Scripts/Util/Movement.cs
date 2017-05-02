using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {
    [SerializeField] private Sights sights;
    [SerializeField] private float m_MaxSpeed = 10f;

    private Transform m_GroundCheck;
    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;
	private bool isRunning;

    // Use this for initialization
    void Awake () {
        m_GroundCheck = transform.Find("GroundCheck");
        m_Anim = GetComponentInChildren<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		this.isRunning = false;
    }

	// Update is called once per frame
	void FixedUpdate () {
		this.move ();
		this.manageAnimation ();
    }

	private void move (){
		this.isRunning = false;
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis ("Vertical");

		if (x != 0 || y != 0) {
			this.isRunning = true;
		}

		m_Rigidbody2D.velocity = new Vector2 (x * m_MaxSpeed, y * m_MaxSpeed);
	}
		
	void manageAnimation () {
		this.m_Anim.SetBool ("isRunning", this.isRunning);
        this.transform.rotation = this.sights.getRotationFromPoint(this.transform.position.x, this.transform.position.y);
    }
}
