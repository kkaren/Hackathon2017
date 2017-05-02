using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnWall : MonoBehaviour, IPointerDownHandler {
    [SerializeField] private GameObject horiozontal;
    [SerializeField] private GameObject vertical;
    [SerializeField] private ChangeButtonImage wallRotation;
    [SerializeField] private int maxWalls;
    [SerializeField] private int cooldown;
    private int wallsAmount = 0;
    private float lastShot;

    private void Awake() {
        this.setButtonText();
        this.lastShot = this.cooldown;


        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void FixedUpdate () {
        this.lastShot += Time.deltaTime;

        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began && this.lastShot >= this.cooldown) {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log(mousePosition);


                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit && this.wallsAmount < this.maxWalls && !hit.transform.gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Enemy"))) {
                    if (hit.transform.gameObject.tag == "Grid_horizontal" && this.wallRotation.IsHorizontal) {
                        this.createWall(horiozontal, hit);
                    } else if (hit.transform.gameObject.tag == "Grid_vertical" && !this.wallRotation.IsHorizontal) {
                        this.createWall(vertical, hit);
                    }
                }
            }
        }
    }

    private void createWall(GameObject obj, RaycastHit2D hit) {
        Vector3 position = hit.transform.GetComponent<Collider2D>().bounds.center;
        position.z = -0.5f - UnityEngine.Random.Range(0.0f,1.0f);
        GameObject wall = Instantiate(obj, position, Quaternion.identity, this.transform);
        this.wallsAmount++;
        hit.transform.gameObject.SetActive(false);
        this.setButtonText();
        this.lastShot = 0;
    }

    private void setButtonText() {
        wallRotation.GetComponentInChildren<UnityEngine.UI.Text>().text = (maxWalls - wallsAmount) + "";
    }

    public void OnPointerDown(PointerEventData eventData) {
        throw new NotImplementedException();
    }
}
