using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    public GameObject DoorObject;
    Vector3 OpenLocation,ClosedLocation;
    public float OpenSize;
    public bool Open = false;
    public bool CanOpenDoor = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanOpenDoor = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanOpenDoor = false;
        }
    }
    public void Start()
    {
        OpenLocation = DoorObject.transform.position;
        ClosedLocation = new Vector3(OpenLocation.x, OpenLocation.y + OpenSize, OpenLocation.z);
    }
    public void Update()
    {
        if (CanOpenDoor == true)
        {
            if (Input.GetMouseButtonDown(0) && Open == false)
            {
                Open = true;
                DoorObject.transform.position = ClosedLocation;
            }
            else if (Input.GetMouseButtonDown(0) && Open == true)
            {
                Open = false;
                DoorObject.transform.position = OpenLocation;

            }
        }
       
    }
}
