using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

    public int MoveSpeed;
    public float DestroyFade = 1;
    public bool TimedDeath;
    public GameObject OnContact;
    // Update is called once per frame
    void FixedUpdate()
    {

        //Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y); //Supposedly binds firepoint to screen/mouse aspect:ratio...
        transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
       
        Destroy(this.gameObject, DestroyFade);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("DefaultBullet")
            || collision.gameObject.CompareTag("Player"))
        {
            Instantiate(OnContact, transform.localPosition, transform.localRotation);
            Destroy(gameObject);
        }
    }
}
