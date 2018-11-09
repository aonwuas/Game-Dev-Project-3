using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    bool inLoading = false;
    public bool pickable;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void release(GameObject holder) {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!inLoading) { //not on catapult
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<Holding>().ToggleHoldable(gameObject, true);
            }
            if(other.tag == "LoadingZone") {
                other.gameObject.GetComponent<Holding>().ToggleHoldable(gameObject, true);
                inLoading = true;
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
