using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour {
    private GameObject player, girl = null, projectile = null;
    private Vector3 facing;
    private ProjectileController proj;
    private GameObject loadingZone;
    private float threshhold = 10f; //angle tolerance between girl and catapult direction
    private float velocity_multiplier = 5f;
	// Use this for initialization
	void Start () {
        projectile = GameObject.Find("Projectile");
        girl = GameObject.Find("Girl");
        if (projectile) { Debug.Log("Projectile found and set"); }
        if (girl) { Debug.Log("Girl found and set"); }
        projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Space)) {
            LaunchCatapult();
        }
	}

    void LaunchCatapult() {
        if(projectile != null) { //catapult is loaded
            Vector3 girl_pos = girl.GetComponent<Transform>().position;
            Vector3 relative_direction = girl_pos - projectile.transform.position;
            relative_direction.y = 0;
            if(is_facing(facing, relative_direction, threshhold)) {//catapult is somewhat facing the girl
                proj = projectile.GetComponent<ProjectileController>();
                proj.Release();
                projectile.GetComponent<Rigidbody>().velocity = velocity_multiplier * (relative_direction.normalized + (2f * Vector3.up));
                
                Debug.Log("Launched projectile towards" + relative_direction);
            }
            else {
                Debug.Log("Error! No projectile loaded!");
            }
        }
    }

    void RotateCatapult() {

    }

    void LoadCatapult(GameObject new_projectile) {
        projectile = new_projectile;
        moveProjectileToLoadingZone(projectile);
    } 
    
    void moveProjectileToLoadingZone(GameObject projectile) {

    }

    bool is_facing(Vector3 v1, Vector3 v2, float tolerance) {
        float relative_angle = Vector3.SignedAngle(v1, v2, Vector3.up);
        // return Mathf.Abs(relative_angle) <= tolerance
        return true;
    }
}
