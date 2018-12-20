using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMechanic : MonoBehaviour {

    Rigidbody rb;
    public float JumpPower;
    public bool canjump;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        canjump = true;
    }
    void FixedUpdate () {
        if (canjump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canjump = false;
                rb.AddForce(Vector3.up * JumpPower * 100, ForceMode.Force);
            }
        }
       
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canjump = true;
        }
    }
}
