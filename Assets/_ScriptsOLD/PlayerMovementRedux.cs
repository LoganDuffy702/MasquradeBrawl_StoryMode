using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerMovementRedux : MonoBehaviour {

    Vector3 direction;
    public int Speed;
    int checkspeed;
    Vector3 currVel;
    
    //float MoveNum;

    public GameObject CharacterAnimation;

    Animator anim;

    public GameObject Weapon;
   // Transform WSTrans;
    public float PlayerX, PlayerY;

   // SpriteRenderer WSsr;
    SpriteRenderer PlayerSprite;

    Rigidbody2D rb2;
    //CapsuleCollider2D CC2D;

    void Start()
    {
      
      //  rb2 = gameObject.GetComponent<Rigidbody2D>();
        //CC2D = gameObject.GetComponent<CapsuleCollider2D>();
      //  WSTrans = Weapon.GetComponent<Transform>();
      //  WSsr = Weapon.GetComponent<SpriteRenderer>();
        anim = CharacterAnimation.GetComponent<Animator>();
       // checkspeed = Speed;
        PlayerSprite = CharacterAnimation.GetComponent<SpriteRenderer>();
        //  StartCoroutine(SpeedCheck());
        Recreate();
        
    }
    //public IEnumerator SpeedCheck()
    //{
    //    yield return new WaitForSeconds(5f);
    //    if (Speed < checkspeed)
    //    {
    //        Speed = checkspeed;
    //    }
    //    StartCoroutine(SpeedCheck());
    //}

    public void Recreate()
    {
        gameObject.transform.position = new Vector3(PlayerX,PlayerY,0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", Mathf.Abs(direction.x));
            transform.Translate(direction.x * Speed * Time.deltaTime, 0, 0);
        }
        
    }
    

    //public void Gravity_PP()
    //{
    //    rb2.gravityScale = -2.5f;
    //    //CC2D.offset = new Vector2(0f, 0.15f);
    //    WSTrans.transform.localPosition = new Vector2(0.007f, -0.32f);
    //    WSsr.flipY = true;
    //    PlayerSprite.flipY = true;
       
    //    StartCoroutine(FlipTimer());

    //}

    //public IEnumerator FlipTimer()
    //{
    //    yield return new WaitForSeconds(3f);
    //    Gravity_PP_Fix();
    //}

    //public void Gravity_PP_Fix()
    //{
        
    //    rb2.gravityScale = 5f;
    //    //CC2D.offset = new Vector2(0f, -0.12f);
    //    WSTrans.transform.localPosition = new Vector2(0.007f, 0.32f);
    //    WSsr.flipY = false;
    //    PlayerSprite.flipY = false;

    //}

}
