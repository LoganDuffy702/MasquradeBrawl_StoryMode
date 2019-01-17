using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour {

    public GameObject Player;
    BoxCollider PlayerCollider;
    public bool count = false;
    int w = 0;
    BoxCollider ObjectsCollider;

    private void Start()
    {
        PlayerCollider = Player.GetComponent<BoxCollider>();
        ObjectsCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update () {
       
 
        if (Input.GetKey(KeyCode.E) && count == true)
        {
            count = false;
            w += 1;
            StartCoroutine(Change());
            
        }
       
    }
    public IEnumerator Change()
    {
        if (w > 1)
        {
            w = 0;
        }
        if (w == 0)
        {
            ObjectsCollider.enabled = true;
        }
        else if (w == 1)
        {
            ObjectsCollider.enabled = false;
        }
        yield return new WaitForSeconds(.2f);
        count = true;

    }

}
