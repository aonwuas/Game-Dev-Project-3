using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour {
    private Holding holder;
    //private CatapultController catapult;
    public bool ready = false;
	// Use this for initialization
	void Start () {
        holder = gameObject.GetComponent<Holding>();
        //catapult = GetComponentInParent<CatapultController>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F)) {
            Debug.Log(holder.isHolding);
        }
        if(holder.isHolding) { 
            holder.updatePosition(transform.position + Vector3.up);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Fire();
            }

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Pickable obj = other.gameObject.GetComponent<Pickable>();
        if(obj && obj.canPick() && !ready) {//if pickable
            Debug.Log("Sticking: " + Time.time);
            holder.ToggleHoldable(other.gameObject, true);
            holder.pickUp(transform.position);
            ready = true;
        }
    }

    private void Fire() {
        if(ready) {
            Debug.Log("Firing");
            holder.Launch();
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        ready = false;
    }



}
