using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultController : MonoBehaviour {

    // Use this for initialization
    private bool ready = false;
    private SpoonController spoon;
    private Pickable projectile;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)){
            Fire();
        }
	}


    public void readyFire(SpoonController newSpoon, Pickable newProjectile) {
        spoon = newSpoon;
        projectile = newProjectile;
        ready = true;
    }

    public void Fire() {
        if(ready) {
            projectile.holder.GetComponent<Holding>().releaseItem(spoon.transform.position);
            Debug.Log("Firing!");
            
            projectile.GetComponent<Rigidbody>().AddForce(Vector3.up * 1f);
            ready = false;
            spoon = null;
            projectile = null;
        }
    }
}
