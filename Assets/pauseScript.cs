using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pauseScript : MonoBehaviour {
	private bool pause=false;
	[SerializeField]
	private Text pauseText;
	// Use this for initialization
	void Start () {
		if(pauseText!=null){
			pauseText.text="";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)&&!pause){
			Time.timeScale=0.0f;
			if(pauseText!=null){
			pauseText.text="Paused";
			}
			pause=true;
		}
		else if(Input.GetKeyDown(KeyCode.P)){
			Time.timeScale=1.0f;
			pause=false;
			if(pauseText!=null){
			pauseText.text="";
			}
		}
		
	}
}
