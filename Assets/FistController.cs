using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistController : MonoBehaviour {
    private GameObject player;
    private GameObject table;
    private Rigidbody body;
    private Projector shadow;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        table = GameObject.Find("Table");
        shadow = GetComponentInChildren<Projector>();
        shadow.enabled = false;
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        StartCoroutine(Smash());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator Smash() {
        Vector3 target = player.transform.position;
        target.y = table.transform.position.y;
        transform.position = target + new Vector3(0, 20, 0);
        shadow.enabled = true;
        yield return new WaitForSeconds(2);
        body.velocity = new Vector3(0, -50f, 0);
        
    }

    IEnumerator Lift() {
        yield return new WaitForSeconds(2);
        body.velocity = new Vector3(0, 10, 0);
        StartCoroutine(Pause());
    }

    IEnumerator Pause() {
        yield return new WaitForSeconds(4);
        body.velocity = Vector3.zero;
        StartCoroutine(Smash());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Table") {
            body.velocity = Vector3.zero;
            shadow.enabled = false;
            Shockwave();
            StartCoroutine(Lift());
        }
    }

    private void Shockwave() {
        //player.GetComponent<PlayerState>().KnockBack(gameObject);
    }
    
}
