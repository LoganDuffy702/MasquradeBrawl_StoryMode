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
    public void Update()
    {
        if (Knockback == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * 20f;
            Knockback = false;
        }
        
    }
}
