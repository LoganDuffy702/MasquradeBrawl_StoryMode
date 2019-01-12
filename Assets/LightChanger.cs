using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour {

    public Light WorldLight;
    public Color Day;
    public Color Night;
    public Color BloodMoon;
    
    

    private void Start()
    {
        WorldLight.color = Day;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            WorldLight.color = Day;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            WorldLight.color = Night;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            WorldLight.color = BloodMoon;
        }
       
	}
}
