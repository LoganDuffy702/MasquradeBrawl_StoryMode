using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {

    public float distance;
    public float speed;
    public bool updown, leftright, forwardback, attackPlayer,followPlayer;
    public GameObject Player;

    private Vector3 smoothVelocity = Vector3.zero;
    public GameObject typeofBullet,firepoint;
    public float attacktime;
    public float ClosestDistance;
    public float chaserange;
    float Proxy;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(Fire());
    }
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
            transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,Time.deltaTime*speed);    
        }
        Proxy = Vector3.Distance(Player.transform.position, transform.position);
       
        if (Proxy <= chaserange)
        {
            if (Proxy <= ClosestDistance)
            {
                followPlayer = false;
                transform.LookAt(Player.transform.position);
                attackPlayer = false;
            }
            else
            {
                followPlayer = true;
                transform.LookAt(Player.transform.position);
                attackPlayer = true;      
            } 
        }
        else
        {
            followPlayer = false;
        }

      

    }
    public IEnumerator Fire()
    {
        yield return new WaitForSeconds(attacktime);
        //if (attackPlayer == true)
        //{
           
        //}
        var bullet = Instantiate(typeofBullet);
        bullet.transform.position = firepoint.transform.position;
        bullet.transform.rotation = firepoint.transform.rotation;
        StartCoroutine(Fire());

    }
}
