using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour {
	[SerializeField]
	private GameObject holder;
	private GameObject currentPowerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Jump")==1&&currentPowerUp!=null){
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
		
	}
}
