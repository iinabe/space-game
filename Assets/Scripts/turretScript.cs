using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour
{
    public float Range;

    public Transform Target;

    bool Detected = false;


    Vector2 Direction;

    public GameObject Gun;

    public GameObject Bullet;

    public float FireRate;

    float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
        //Direction.sqrMagnitude < Range * Range;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        Debug.Log(targetPos);

        if (rayInfo)
        {

            //Detected = !Detected;
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }

        if (Detected)
        {
            Debug.Log("3");
            Gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }

    }


    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
