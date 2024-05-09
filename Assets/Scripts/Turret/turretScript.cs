using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class turretScript : MonoBehaviour
{
    public event Action<turretScript> OnDie;

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

    public string targetTag = "Player";


    void FixedUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(targetTag);

        if (players.Length > 0)
        {
            Target = players[0].transform;
            Vector2 targetPos = Target.position;
            Direction = targetPos - (Vector2)transform.position;
            Detected = Direction.sqrMagnitude < Range * Range;

            if (Detected)
            {
                Gun.transform.up = Direction;
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    shoot();
                }
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
    public void HpLost()
    {
        OnDie?.Invoke(this);
    }

    public void Die()
    {
        //Destroy(gameObject);
    }
}
