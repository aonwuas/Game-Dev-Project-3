using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAI : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float smashSpeed;
	private float beginY;
	private bool falling=false;
	private Rigidbody rb;
	private bool rising=false;

	// Use this for initialization
	void Start () {
		beginY=transform.position.y;
		rb=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(rising);
		Vector3 playerPos=player.transform.position;
		playerPos.y=transform.position.y;
		//if the girl is in a certain distance to the player, then she will attempt to attack, otherwise she will move towards the player
		if(Mathf.Abs(transform.position.x-playerPos.x)<.5&&Mathf.Abs(transform.position.z-playerPos.z)<.5&&!falling&&!rising){
			falling=true;
		}
		if(falling){
			transform.position=new Vector3(transform.position.x,transform.position.y-smashSpeed*Time.deltaTime,transform.position.z);
		}
		else if (!rising){
			transform.position=Vector3.MoveTowards(transform.position,playerPos,speed*Time.deltaTime);
		}
		else{
			if(transform.position.y<beginY){
				transform.position=new Vector3(transform.position.x,transform.position.y+speed*Time.deltaTime,transform.position.z);
				rb.velocity=Vector3.zero;
			}
			else{
				rising=false;
			}
		}
		
		
	}
	void OnCollisionEnter(Collision col){
	if(col.gameObject.layer==LayerMask.NameToLayer("Ground")){
		//just checking collision with different layers, change to what ever layer the hazards for the girl are and update the girl's health
	}
	else{
		//do something different??
	}
		falling=false;
		rising=true;
		//transform.position=new Vector3(transform.position.x,beginY,transform.position.z);
		rb.velocity=Vector3.zero;
	}
}
