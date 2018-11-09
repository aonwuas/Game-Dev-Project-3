using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour {
	[SerializeField]
	private Text playerHealth;
	[SerializeField]
	private PlayerState playerState;
	[SerializeField]
	private Text girlHealth;
	[SerializeField]
	private GirlHealth girl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth.text="Player: "+playerState.getHeath();
		girlHealth.text="Girl: "+girl.getHealth();
	}
}
