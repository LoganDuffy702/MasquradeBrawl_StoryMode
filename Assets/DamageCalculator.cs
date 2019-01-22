using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour {

    public bool Knockback = false;
   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Knockback = true;
        }
        
    }
    public void FixedUpdate()
    {
        if (Knockback == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 50);
            Knockback = false;
        }
    }
}
