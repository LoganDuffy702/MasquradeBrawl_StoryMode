﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWalk : MonoBehaviour
{

    public GameObject PlayerShell;
    public GameObject SpriteMask;
    public GameObject ShellSprite;
    public GameObject ShellWeapon;
    Vector3 SavedLocation;
    SpriteMask mask;
    private int Change = 0;
    private bool freeze = false;
    private bool CanLeave = false;
    private bool Shadowmode = true;


    // Use this for initialization
    void Start()
    {
        mask = SpriteMask.GetComponent<SpriteMask>();

        
        ShellSprite.GetComponent<SpriteRenderer>().enabled = false;
        ShellWeapon.GetComponent<SpriteRenderer>().enabled = false;
        mask.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze == true)
        {
            PlayerShell.transform.position = SavedLocation;
        }
        else
        {
            PlayerShell.transform.position = gameObject.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Change += 1;
            if (Change > 1)
            {
                Change = 0;
            }
            if (Change == 1)
            {
                CanLeave = true;
            }
            else if (Change == 0)
            {
                CanLeave = false;
            }


        }
       
        if (CanLeave == true && Shadowmode == false)
        {
            SavedLocation = gameObject.transform.position;
            freeze = true;
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            ShellSprite.GetComponent<SpriteRenderer>().enabled = true;
            ShellWeapon.GetComponent<SpriteRenderer>().enabled = true;
            mask.enabled = true;
            Shadowmode = true;
            

        }
        else if (CanLeave == false && Shadowmode == true)
        {
            freeze = false;
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            ShellSprite.GetComponent<SpriteRenderer>().enabled = false;
            ShellWeapon.GetComponent<SpriteRenderer>().enabled = false;

            //Add a lerp when returning 
            gameObject.transform.position = SavedLocation;
            mask.enabled = false;
            Shadowmode = false;

        }
    }
}
