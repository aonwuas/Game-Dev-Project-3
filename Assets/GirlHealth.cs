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
			Time.timeScale=0.0f;
			//change scene here(?)
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
        Pickable p = other.gameObject.GetComponent<Pickable>();
        if(p) {
            health -= 1;
        }
		/*if(other.gameObject.tag=="Cherry"){
			health-=1;
		}*/
	}
	public int getHealth(){
		return health;
	}
}
