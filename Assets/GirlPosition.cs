using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlPosition : MonoBehaviour {
	//use 3 empty game objects to get the position of the girl's body, the 1st position should be the girl's starting position
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private Transform pos2;
	[SerializeField]
	private Transform pos3;
	[SerializeField]
	private Transform pos4;
	[SerializeField]
	private Transform pos1;
	private Vector3 position1;
	private Vector3 position2;
	private Vector3 position3;
	private Vector3 position4;
	private Vector3 playerPos;
	private float[] magList;

	// Use this for initialization
	void Start () {
		magList=new float[4];
		position1=transform.position;
		position2=pos2.position;
		position3=pos3.position;
		position4=pos4.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		playerPos=player.transform.position;
		magList[0]=Vector3.Magnitude(playerPos-position1);
		magList[1]=Vector3.Magnitude(playerPos-position2);
		magList[2]=Vector3.Magnitude(playerPos-position3);
		magList[3]=Vector3.Magnitude(playerPos-position4);
		float min=Mathf.Min(magList);
		if(min==magList[1]){
			//the rotations will need to be adjusted once the model gets imported
			transform.position=position2;
			transform.rotation=Quaternion.Euler(0,90,0);
		}
		else if(min==magList[2]){
			transform.rotation=Quaternion.Euler(0,0,0);
			transform.position=position3;
		}
		else if(min==magList[3]){
			transform.position=position4;
			transform.rotation=Quaternion.Euler(0,90,0);
		}
		else{
			transform.position=position1;
			transform.rotation=Quaternion.Euler(0,0,0);
		}
	}
}
