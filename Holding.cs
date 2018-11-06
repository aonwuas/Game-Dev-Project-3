using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour {
	[SerializeField]
	private GameObject holder;
	[SerializeField]
	private float knockbackFactor;
	private GameObject currentPowerUp;
	private Vector3 knockback;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
			rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)&&currentPowerUp!=null){
			currentPowerUp.transform.parent=null;
			currentPowerUp.transform.position=new Vector3(currentPowerUp.transform.position.x+1,currentPowerUp.transform.position.y,currentPowerUp.transform.position.z);
			currentPowerUp=null;
		}
		
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag=="Cherry"&&currentPowerUp==null){
			col.gameObject.transform.position=holder.transform.position;
			col.gameObject.transform.parent=transform;
			currentPowerUp=col.gameObject;
		}
		if(col.gameObject.tag=="Hand"){
			knockback=transform.position-col.gameObject.transform.position;
			knockback.y=0;
			if(knockback==Vector3.zero){
				knockback.x=1;
			}
			knockback=knockback.normalized;
			rb.AddForce(knockback*knockbackFactor);
		}
		
	}
}
