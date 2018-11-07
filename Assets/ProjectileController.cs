using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    GameObject loadingZone;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 0.8f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(loadingZone) {
            transform.position = loadingZone.transform.position + offset;
            transform.rotation = loadingZone.transform.rotation;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }


    public void Stick(GameObject sticker) {
        loadingZone = sticker;
    }

    public void Release() {
        loadingZone = null;
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
