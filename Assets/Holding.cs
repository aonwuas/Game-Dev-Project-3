using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour {
	[SerializeField]
	private GameObject holder;
	[SerializeField]
	private float knockbackFactor;
	[SerializeField]
	private int health=3;
	private GameObject currentPowerUp;
	private Vector3 knockback;
	private Rigidbody rb;
	private Rigidbody powerRb;

	// Use this for initialization
	void Start () {
			rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentPowerUp!=null){
			currentPowerUp.transform.position=holder.transform.position;
		}
		if(Input.GetKeyDown(KeyCode.E)&&currentPowerUp!=null){
			currentPowerUp.transform.localPosition=new Vector3(2,currentPowerUp.transform.localPosition.y,currentPowerUp.transform.localPosition.z);
			currentPowerUp.transform.parent=null;
			if(powerRb!=null){
				powerRb.detectCollisions=true;
				powerRb=null;
			}
			currentPowerUp=null;
		}
		if(health<=0){
			Debug.Log("you died, rip");
		}
		
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag=="Cherry"&&currentPowerUp==null){
			col.gameObject.transform.position=holder.transform.position;
			col.gameObject.transform.parent=transform;
			currentPowerUp=col.gameObject;
			powerRb=currentPowerUp.GetComponent<Rigidbody>();
			if(powerRb!=null){
				 powerRb.detectCollisions = false;
			}
		}
		if(col.gameObject.tag=="Hand"){
			knockback=transform.position-col.gameObject.transform.position;
			knockback.y=0;
			health--;
			if(knockback==Vector3.zero){
				knockback.x=1;
			}
			knockback=knockback.normalized;
			rb.AddForce(knockback*knockbackFactor);
		}
		
	}
}
