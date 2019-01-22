using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShadowObject : MonoBehaviour {
    public bool Hidden = false;
    public bool box, sphere;
	// Use this for initialization
	void Start () {
        if (box)
        {
            BoxCollider BC = gameObject.AddComponent<BoxCollider>() as BoxCollider;
            BC.center = new Vector3(0f, 0f, 6f);
            if (Hidden == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }

        if (sphere)
        {
            SphereCollider BC = gameObject.AddComponent<SphereCollider>() as SphereCollider;
            BC.center = new Vector3(0f, 0f, 6f);
            if (Hidden == true)
            {
                gameObject.GetComponent<SphereCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }
      
	}
	
}
