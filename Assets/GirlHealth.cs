using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlHealth : MonoBehaviour {
	// put this on the girl's body, rn the health only changes when the cherry hits the body but not the hand
	[SerializeField]
	private int health=5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health==0){
			Debug.Log("the girl is dead");
			//change scene here(?)
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Cherry"){
			health-=1;
		}
	}
}
