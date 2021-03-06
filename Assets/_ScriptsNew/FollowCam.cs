﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject Player;
    Vector3 Player_pos;
    public float TravelSpeed;
    public float Yoffset;
    public float Zoom = -15f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player_pos = Player.transform.position;
        Player_pos.z = Zoom;
        Player_pos.y = Player_pos.y + Yoffset;
        //work in progress.
        //transform.position = Vector3.Lerp(transform.position,Player_pos,TravelSpeed);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Player_pos, TravelSpeed);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Yoffset, Camera.main.transform.position.z);
        //Camera.main.transform.LookAt(transform);
    }
}
