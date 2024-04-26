using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    void FixedUpdate()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        Debug.Log(targetPos);


        if (rayInfo && rayInfo.collider.gameObject.tag == "Player")
        {
            Detected = Direction.sqrMagnitude < Range * Range;
        }
        else
        {
            Detected = false;
        }


        if (Detected)
        {
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
    private void OnDestroy()
    {
        TurretSpawner spawner = FindObjectOfType<TurretSpawner>(); // Находит объект TurretSpawner в сцене
        if (spawner != null)
        {
            spawner.TurretDestroyed(); // Вызов события TurretDestroyed
        }
    }
}
