using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour {
	[SerializeField]
	private GameObject heldItem;
	private Rigidbody itemRb;
    private GameObject objectToPick;
    public bool canPickUp = false;
    public bool isHolding = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void pickUp(Vector3? holdPosition = null) {
        heldItem = objectToPick;
        heldItem.GetComponent<Pickable>().pick(this.gameObject);
        if(holdPosition == null) {
            holdPosition = Vector3.zero;
        }
        updatePosition((Vector3) holdPosition);
        heldItem.transform.parent = transform;
        objectToPick = null;
        canPickUp = false;
        heldItem.transform.localEulerAngles = Vector3.zero;
        itemRb = heldItem.GetComponent<Rigidbody>();
        if (itemRb != null)
        {
            itemRb.detectCollisions = false;
        }
        isHolding = true;
    }

    public void HoldingReset() {
        canPickUp = false;
        isHolding = false;
        heldItem = null;
        itemRb = null;
        objectToPick = null;
    }

    public void updatePosition(Vector3 position) {
        heldItem.transform.position = position;
    }

    public void releaseItem(Vector3 direction) {
        heldItem.transform.parent = null;
        heldItem.transform.position = transform.position + direction;
        Rigidbody itemRb = heldItem.GetComponent<Rigidbody>();
        if(itemRb) {
            itemRb.velocity = Vector3.zero;
            itemRb.detectCollisions = true;
            //itemRb = null;
        }
        heldItem.GetComponent<Pickable>().release();
        heldItem = null;
        isHolding = false;
    }
    

    public void ToggleHoldable(GameObject obj, bool hold) {
        if(hold) {
            if(!heldItem && !objectToPick){
                objectToPick = obj;
                canPickUp = true;
            }
        }
        else {
            if(objectToPick == obj) {
                objectToPick = null;
                canPickUp = false;
            }
        }
    }
}
