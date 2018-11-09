using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    public bool pickable;
    GameObject holder;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void release() {
        holder = null;
    }

    public void pick(GameObject newHolder) {
        holder = newHolder;
    }

    public bool canPick() {
        return holder == null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!holder) { //not currently held
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<Holding>().ToggleHoldable(gameObject, true);
            }
        }
        
    }
    

    public void UpdateItemPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") {
            other.gameObject.GetComponent<Holding>().ToggleHoldable(gameObject, false);
        }
    }
}
