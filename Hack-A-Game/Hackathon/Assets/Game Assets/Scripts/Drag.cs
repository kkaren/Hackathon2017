using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : EventTrigger {
    private Vector3 initPosition;

    public void Awake() {
        this.initPosition = this.transform.position;
    }

    public override void OnDrag(PointerEventData eventData) {
        base.OnDrag(eventData);
        this.transform.position = eventData.position;
    }

    public override void OnEndDrag(PointerEventData eventData) {
        base.OnEndDrag(eventData);
        this.transform.position = this.initPosition;
    }
}
