using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour {
    private Holding holder;
	// Use this for initialization
	void Start () {
        holder = gameObject.GetComponent<Holding>();
    }
	
	// Update is called once per frame
	void Update () {
        if(holder.isHolding) { 
            holder.updatePosition(transform.position + Vector3.up);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Pickable obj = other.gameObject.GetComponent<Pickable>();
        if(obj && obj.canPick()) {//if pickable
            holder.ToggleHoldable(other.gameObject, true);
            holder.pickUp(transform.position);
        }
    }
    

}
