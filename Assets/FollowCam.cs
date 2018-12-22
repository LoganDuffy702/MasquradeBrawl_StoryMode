using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public GameObject Player;
    Vector3 Player_pos;
    public float TravelSpeed;
    public float Yoffset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player_pos = Player.transform.position;
        Player_pos.z = transform.position.z;
        Player_pos.y = Player_pos.y + Yoffset;
        //work in progress.
        //transform.position = Vector3.Lerp(transform.position,Player_pos,TravelSpeed);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, Player_pos, 0.03f);
        //Camera.main.transform.LookAt(transform);
    }
}
