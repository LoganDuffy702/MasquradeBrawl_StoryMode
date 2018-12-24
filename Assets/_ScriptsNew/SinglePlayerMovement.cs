using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour {

    public int speed;
    public GameObject CharcterAnimation;
    public GameObject Weapon;
    public float SpawnX, SpawnY;
    public bool runspeed;
    float zPos;

	// Use this for initialization
	void Start () {
		
	}
    public void Recreate()
    {
        gameObject.transform.position = new Vector3(SpawnX, SpawnY, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        zPos = gameObject.transform.position.z;

        if (Input.GetKey(KeyCode.D)) 
        { 
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            runspeed = Input.GetKey(KeyCode.A);
            transform.Translate(-speed * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            runspeed = Input.GetKey(KeyCode.W);
            if (zPos > 12f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 12f);
                transform.Translate(0, 0, 0);
            }
            else
            {
                transform.Translate(0, 0, (speed / 2) * Time.deltaTime);
            }    
        }
        if (Input.GetKey(KeyCode.S))
        {
            runspeed = Input.GetKey(KeyCode.S);
            if (zPos <= -.5f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -.2f);
                transform.Translate(0, 0, 0);
            }
            else
            {
                transform.Translate(0, 0, -(speed / 2) * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            CharcterAnimation.GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            CharcterAnimation.GetComponent<Animator>().SetBool("Run", false);
        }

        if (zPos <= -.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -.2f);
        }
    }
   
}
