﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	[SerializeField]
	private float hSpeed = 4.0f;
	[SerializeField]
	private float vSpeed = 4.0f;
	[SerializeField]
    private Transform player;
	[SerializeField]
	private float yBound;
	[SerializeField]
	private float minY;
	[SerializeField]
	private float maxY;
    private Vector3 offset;
    void Start () {
        offset = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }
  
    void Update()
    {
		//Used https://answers.unity.com/questions/600577/camera-rotation-around-player-while-following.html as a reference
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * hSpeed, Vector3.up) * offset;
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * vSpeed, Vector3.right) * offset;
        
        offset.y = Mathf.Max(0.2f, offset.y); //prevent from falling through floor.
        transform.position = player.position + offset;
            
		//this bounds y to between minY and maxY
		//transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z); 
        transform.LookAt(player.position);

    }
}
