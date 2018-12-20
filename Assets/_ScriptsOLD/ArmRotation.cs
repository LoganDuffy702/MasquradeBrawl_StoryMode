using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

    public GameObject PlayerAnimation;
    SpriteRenderer PlayerSprite;
	SpriteRenderer sr; 
	//private Transform objectPostion;

	void Start(){
		sr = GetComponent<SpriteRenderer> ();
        PlayerSprite = PlayerAnimation.GetComponent<SpriteRenderer>();
    }
	void Update () {
       
        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint( transform.position);
      
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);

        if (difference.x < 0)
        {
            sr.flipY = true;
            sr.flipX = true;
            PlayerSprite.flipX = false;
        }
        else if (difference.x > 0)
        {
            sr.flipY = false;//change to y...
            PlayerSprite.flipX = true;
        }
    }
  
}
