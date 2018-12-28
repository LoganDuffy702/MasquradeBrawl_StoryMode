using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenarator : MonoBehaviour {

    public List<GameObject> Platforms;
    public GameObject Player;
    private GameObject lastPlatform;
    GameObject Endpoint;
   // Transform StartPoint;
    float Proxy;
    bool spawn;
    public int FirstSpawn = 0;

	// Use this for initialization
	void Start () {
        //CreateNextPlaatform(1);
        FirstSpawn = 1;
        for (int i = 0; i <20; i++)
        {
            CreateNextPlaatform(i);
        }
    }
	// Update is called once per frame
	void Update () {
        //Proxy = Vector3.Distance(Player.transform.position, Endpoint.transform.position);
        //if (Proxy < 3f && spawn == true)
        //{
        //    spawn = false;
        //    CreateNextPlaatform();
        //}
	}

    private GameObject RandomPlatform()
    {
        int r = Mathf.FloorToInt(Random.value * Platforms.Count);
        return Platforms[r];
    }

    private void CreateNextPlaatform(int count)
    {
        if (FirstSpawn == 0)
        {
            lastPlatform = Instantiate(RandomPlatform());
            //Endpoint = GameObject.find("Endpoint");
           // StartPoint = lastPlatform.transform.Find("StartPoint");
            lastPlatform.transform.position = new Vector3(0f, 0f, 0f);

            spawn = true;
        }
        else
        {
            lastPlatform = Instantiate(RandomPlatform());
           // Endpoint = lastPlatform.transform.Find("Endpoint");
           // StartPoint = lastPlatform.transform.Find("StartPoint");
            lastPlatform.transform.position = new Vector3(33.5f*count, 0, 0);// Endpoint.transform.position+ 

            spawn = true;
        }
       
    }

}
