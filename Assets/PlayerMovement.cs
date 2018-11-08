using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	private float speed;
	[SerializeField]
	private float jump;
	[SerializeField]
	private LayerMask ground;
	[SerializeField]
	private float airSpeedAdjust=8;
	private float vert;
	private float hori;
	private Vector3 direction;
	private Vector3 camFoward;
	private Vector3 camRight;
	private Rigidbody rb;
	private float oriSpeed;
	private Quaternion rot;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();
		oriSpeed=speed;
	}
	
	// Update is called once per frame
	void Update () {
		vert=Input.GetAxis("Vertical");
		hori=Input.GetAxis("Horizontal");
		rot=Camera.main.transform.rotation;
		rot.x=0;
		rot.z=0;
		transform.rotation=rot;
		transform.rotation=Quaternion.Euler(0,transform.eulerAngles.y+90*hori,0);
	}
	void FixedUpdate()
	{
		//movement relative to camera based off of https://forum.unity.com/threads/moving-character-relative-to-camera.383086/
		camFoward=Camera.main.transform.forward;
		camRight=Camera.main.transform.right;
		camFoward.y=0;
		camRight.y=0;
		direction=(camFoward*vert+camRight*hori).normalized;
		rb.AddForce(direction*speed);
		if(Input.GetAxis("Jump")==1){
			if(IsGrounded()){
				rb.AddForce(Vector3.up*jump,ForceMode.Impulse);
				speed=oriSpeed/airSpeedAdjust;
			}
		}
		else{
			//speed=oriSpeed;
		}
		
	}
	bool IsGrounded() {
		if (Physics.Raycast(this.transform.position, Vector3.down, 2f, ground.value)) {
			return true;
		}
		else {
			return false;
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.layer==LayerMask.NameToLayer("Ground")){
			Debug.Log("ouch");
			speed=oriSpeed;
		}
	}
}
