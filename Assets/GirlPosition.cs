using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlPosition : MonoBehaviour {
	//use 3 empty game objects to get the position of the girl's body, the 1st position should be the girl's starting position
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private Transform table;
	[SerializeField]
	private float distance=50;
	private Vector3 direction;
	private Vector3 playerPos;
	private Vector3 center;
	private Vector3 rot;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		center=table.transform.position;
		playerPos=player.transform.position;
		direction=playerPos-center;
		direction.y=0;
		direction=direction.normalized;
		transform.position=direction*distance+center;
		transform.LookAt(player.transform);
		rot=transform.eulerAngles;
		rot.x=0;
        rot.y -= 90;
		transform.eulerAngles=rot;
		
	}
}
