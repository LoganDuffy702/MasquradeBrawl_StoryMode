using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWalk : MonoBehaviour
{

    public GameObject PlayerShell;
    public GameObject SpriteMask;
    public GameObject ShellSprite;
    public GameObject ShellWeapon;
    public Vector3 SavedLocation;
    SpriteMask mask;
    public bool freeze = false;
    public bool CanLeave = false;
    bool Shadowmode = true;
    

    // Use this for initialization
    void Start()
    {
        mask = SpriteMask.GetComponent<SpriteMask>();
        
        //PlayerShell.transform.position = new Vector3(1f, 0f, 5f);
        ShellSprite.GetComponent<SpriteRenderer>().enabled = false;
        ShellWeapon.GetComponent<SpriteRenderer>().enabled = false;
        mask.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
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
            CanLeave = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CanLeave = false;
        }

        if (CanLeave == true && Shadowmode == false)
        {
            SavedLocation = gameObject.transform.position;
            freeze = true;
            
            ShellSprite.GetComponent<SpriteRenderer>().enabled = true;
            ShellWeapon.GetComponent<SpriteRenderer>().enabled = true;
            mask.enabled = true;
            Shadowmode = true;

        }
        else if (CanLeave == false && Shadowmode == true)
        {
            freeze = false;
            ShellSprite.GetComponent<SpriteRenderer>().enabled = false;
            ShellWeapon.GetComponent<SpriteRenderer>().enabled = false;

            //Add a lerp when returning 
            gameObject.transform.position = SavedLocation;
            mask.enabled = false;
            Shadowmode = false;

        }
    }
}
