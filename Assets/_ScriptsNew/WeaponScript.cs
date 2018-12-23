using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public int burstSize = 5;
    public float FireDelay = 12;
    public int bulletspeed;
    //public AudioSource Gunsound;

    public float ReloadSpeed = 1;
    //public string Playercontrols;
    bool CanShoot = true;
    bool showText = false;
    public GameObject TypeOfBullet;
    public int ShotGunBullets = 4;
    public GameObject blastflair;

    public bool ShotGunMode = true;

    //public GameObject GunText;

    public int Ammo = 22;
    //public GameObject AmmoPrefab;
    //private Vector3 temp;
    public GameObject Firepoint;
    //public GameObject AmmoPos;
    //private Image Clips;
    public int removeAmount = 1;

    float fire;

    void Start()
    {
        //Debug.Log(PlayerGun.name);
        // Gunsound = GameObject.Find("PistolSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            if (CanShoot == true)
            {

                if (Ammo > 0)
                {
                    StartCoroutine(Fire());
                    CanShoot = false;
                    StartCoroutine(Reload());

                    if (Ammo == 0)
                    {
                        Debug.Log("OUT OF Ammo");
                    }
                }
            }
            else if (CanShoot == false)
            {
                if (showText == true)
                {
                    //Debug.Log ("Reloading");
                    //StartCoroutine(ReloadFX());
                }
            }
        }


    }

    //timer for reload speed 
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadSpeed);
        CanShoot = true;
    }

    //reload fx
    public IEnumerator ReloadFX()
    {
        //var ReloadText = (GameObject)Instantiate (GunText, transform.position, Quaternion.identity);//popup text
        yield return new WaitForSeconds(ReloadSpeed - 0.3f);
        showText = false;
    }

    //Burst fire 
    public IEnumerator Fire()
    {
        //temp = gameObject.transform.localPosition;
        float bulletDelay = 1 / FireDelay; //Decides the delay between each shot
        for (int i = 0; i < burstSize; i++)
        {
            //gameObject.transform.localPosition = new Vector3(Mathf.Abs(temp.x / 3), temp.y, temp.z);
            //Gunsound.Play();
            if (ShotGunMode == false)
            {
                var bullet = Instantiate(TypeOfBullet);//Basic firing of bullet
                var flair = Instantiate(blastflair);
                flair.transform.position = Firepoint.transform.position;
                flair.transform.rotation = transform.rotation;
                bullet.transform.position = Firepoint.transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.transform.Rotate(0, 0, Random.Range(-1,1));
            }
            else if (ShotGunMode == true)
            {
                for (int w = 0; w < ShotGunBullets; w++)
                {
                    var bullet1 = Instantiate(TypeOfBullet);//Basic firing of bullet
                    bullet1.transform.position = transform.position;
                    bullet1.transform.rotation = transform.rotation;
                    bullet1.transform.Rotate(0, 0, Random.Range(-15, 15));

                }
            }
            //yield return new WaitForSeconds(bulletDelay); //Waits so many seconds before firing
            //gameObject.transform.localPosition = temp;
            yield return new WaitForSeconds(bulletDelay);

        }
        showText = true;
    }

    //InvokeRepeating
}

