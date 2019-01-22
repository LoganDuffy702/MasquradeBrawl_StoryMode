using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {

    public float speed;
    public bool LR = false;
    public bool grounded;
    private Vector3 posCur;
    private Quaternion rotCur;
    public float fallspeed;
    public float Raylenght;
    public float hoverheight;
    public float rotationspeed;
    //public float ClosestDistance;
    //public float chaserange;
    int rotate = 0;
    float Proxy;

    //void Update () {

    //    //if (updown == true)
    //    //{
    //    //    transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 10, distance), transform.position.z);
    //    //}
    //    else if (leftright == true)
    //    {
    //        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, distance), transform.localPosition.y , transform.localPosition.z);


    //    }

    //    if (followPlayer == true)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,Time.deltaTime*speed);    
    //    }
    //    Proxy = Vector3.Distance(Player.transform.position, transform.position);

    //    if (Proxy <= chaserange)
    //    {
    //        if (Proxy <= ClosestDistance)
    //        {
    //            followPlayer = false;
    //            //transform.LookAt(MainCamera.transform.position);
    //            attackPlayer = false;
    //        }
    //        else
    //        {
    //            followPlayer = true;
    //            //transform.LookAt(MainCamera.transform.position);
    //            attackPlayer = true;      
    //        } 
    //    }
    //    else
    //    {
    //        followPlayer = false;
    //    }
    //}

    void FixedUpdate()
    {
        //declare a new Ray. It will start at this object's position and it's direction will be straight down from the object (in local space, that is)
        Ray ray = new Ray(transform.position, -transform.up);
        //decalre a RaycastHit. This is neccessary so it can get "filled" with information when casting the ray below.
        RaycastHit hit;
        //cast the ray. Note the "out hit" which makes the Raycast "fill" the hit variable with information. The maximum distance the ray will go is 1.5
        if (Physics.Raycast(ray, out hit, Raylenght) == true)
        {
            //draw a Debug Line so we can see the ray in the scene view. Good to check if it actually does what we want. Make sure that it uses the same values as the actual Raycast. In this case, it starts at the same position, but only goes up to the point that we hit.
            Debug.DrawLine(transform.position, hit.point, Color.green);
            //store the roation and position as they would be aligned on the surface
            rotCur = Quaternion.FromToRotation(transform.up, hit.lightmapCoord) * transform.rotation;
            posCur = new Vector3(transform.position.x, hit.point.y+hoverheight, transform.position.z);
            grounded = true;
        }
        //if you raycast didn't hit anything, we are in the air and not grounded.
        else
        {
            grounded = false;
        }

        if (grounded == true)
        {
            //smoothly rotate and move the objects until it's aligned to the surface. The "5" multiplier controls how fast the changes occur and could be made into a seperate exposed variable
            transform.position = Vector3.Lerp(transform.position, posCur, Time.deltaTime * fallspeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, Time.deltaTime * rotationspeed);
        }
        else
        {
            //if we are not grounded, make the object go straight down in world space (simulating gravity). the "1f" multiplier controls how fast we descend.
            transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.up * 1f, Time.deltaTime * fallspeed);
            //if we are not grounded, make the vehicle's rotation "even out". Not completey reaslistic, but easy to work with.
            rotCur.eulerAngles = Vector3.zero;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, Time.deltaTime);
        }

        if (LR == true)
        {
            if (rotate > 1)
            {
                rotate = 0;
            }
            if (grounded == false)
            {
                rotate += 1;
                speed = -1 * speed;
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
