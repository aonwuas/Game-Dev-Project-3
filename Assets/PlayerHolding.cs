using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolding : Holding {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Hand")
        {
            knockback = transform.position - col.gameObject.transform.position;
            knockback.y = 0;
            health--;
            if (knockback == Vector3.zero)
            {
                knockback.x = 1;
            }
            knockback = knockback.normalized;
            rb.AddForce(knockback * knockbackFactor);
        }

    }*/
}
