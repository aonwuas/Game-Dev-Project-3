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
        yield return new WaitForSeconds(3);
        body.velocity = new Vector3(0, -50f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground") {
            body.velocity = Vector3.zero;
            shadow.enabled = false;
        }
    }
    
}
