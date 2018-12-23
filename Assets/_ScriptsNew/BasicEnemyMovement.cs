using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {

    public float distance;
    public float speed;
    public bool updown, leftright, forwardback, attackPlayer,followPlayer;
    public GameObject Player;
    private Vector3 smoothVelocity = Vector3.zero;
    public float ClosestDistance;
    public float chaserange;
    public float smoothTime = 10.0f;
    float Proxy;
   
	// Update is called once per frame
	void Update () {
        if (updown == true)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 10, distance), transform.position.z);
        }
        else if (leftright == true)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, distance), transform.position.y , transform.position.z);
          // transform.position =  Vector3.Lerp(starting, ending, Time.time*speed);
        }
        else if (forwardback == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, distance));
        }

        if (followPlayer == true)
        {
           // transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime*speed);
            //transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, Time.deltaTime * speed),0,0);
            transform.position = Vector3.SmoothDamp(transform.position,Player.transform.position, ref smoothVelocity, smoothTime);
           
        }
        Proxy = Vector3.Distance(Player.transform.position, transform.position);
       
        if (Proxy <= chaserange)
        {
            if (Proxy <= ClosestDistance)
            {
                followPlayer = false;
                transform.LookAt(Player.transform.position);
            }
            else
            {
                followPlayer = true;
                transform.LookAt(Player.transform.position);
            } 
        }
        else
        {
            followPlayer = false;
        }
        
    }
}
