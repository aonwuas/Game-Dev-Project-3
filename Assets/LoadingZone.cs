using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZone : MonoBehaviour {

    SpoonController spoon;
    ProjectileController projectile = null;

	// Use this for initialization
	void Start () {
        spoon = GetComponentInParent<SpoonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something collided");
        if (other.gameObject.name == "Projectile" && projectile == null) {
            Debug.Log("It was a projectile!");
            projectile = other.gameObject.GetComponent<ProjectileController>();
            projectile.Stick(gameObject);
        }
    }

    private void Fire() {
    }

    
}
