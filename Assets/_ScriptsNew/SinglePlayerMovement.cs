using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour {

    public int speed;
    public GameObject CharcterAnimation;
    public GameObject Weapon;
    List<float> Zpositions = new List<float>() { 1.2f, 6f} ;
    public float SpawnX, SpawnY;
    public float slidespeed;
    int currentNum = 0;
    public bool runspeed;

    bool front, middle, back;
    bool Move = true;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 1.2f);
	}

    //public void Recreate()
    //{
    //    gameObject.transform.position = new Vector3(SpawnX, SpawnY, 0);
    //}

    //public IEnumerator ChangeLaneUp()
    //{
    //    yield return new WaitForSeconds(.2f);
        
    //    if (currentNum < 1)
    //    {
    //        currentNum += 1;
    //    }
    //    //transform.position = new Vector3(transform.position.x, transform.position.y, Zpositions[currentNum].transform.position.z);
        
    //    Move = true;
    //}
    //public IEnumerator ChangeLaneDown()
    //{
    //    yield return new WaitForSeconds(.2f);

    //    if (currentNum > 0)
    //    {
    //        currentNum = currentNum - 1;
    //    }
    //    //transform.position = new Vector3(transform.position.x, transform.position.y, Zpositions[currentNum]);
        
        
    //    Move = true;
    //}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)) 
        { 
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        //if (Input.GetKey(KeyCode.W) && Move == true)
        //{
        //    Move = false;
        //    StartCoroutine(ChangeLaneUp());
            
        //}
        //if (Input.GetKey(KeyCode.S) && Move == true)
        //{
        //    Move = false;
        //    StartCoroutine(ChangeLaneDown());
        //}

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            CharcterAnimation.GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            CharcterAnimation.GetComponent<Animator>().SetBool("Run", false);
        }
        //transform.position = Vector3.Lerp(transform.position,
        //    new Vector3(transform.position.x,transform.position.y,Zpositions[currentNum]), Time.deltaTime * slidespeed);
    }
   
}
