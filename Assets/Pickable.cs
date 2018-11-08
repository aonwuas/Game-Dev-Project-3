using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            other.gameObject.GetComponent<Holding>().MakeHoldable(gameObject, true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") {
            other.gameObject.GetComponent<Holding>().MakeHoldable(gameObject, false);
        }
    }
}
