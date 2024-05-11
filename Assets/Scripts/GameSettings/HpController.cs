using UnityEngine;
using System.Collections;

public class HpController : MonoBehaviour
{
    public enum ObjectType { Player, Asteroid, Turret }

    public ObjectType objectType;


    private int hp;
    private int maxHp = 100; 
    public AudioClip explosionSound; 
    private AudioSource audioSource; 

    public GameObject Explosion;
    public HealthBar healthBar;

    void Start()
    {
        switch (objectType)
        {
            case ObjectType.Player:
                hp = maxHp;
               if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHp);
        }
                break;
            case ObjectType.Asteroid:
                hp = 3;
                break;
            case ObjectType.Turret:
                hp = 3;
                break;
            default:
                hp = maxHp;
                break;
        }
        audioSource = GetComponent<AudioSource>(); 
    }

    public void MakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {   
            AudioSource.PlayClipAtPoint(explosionSound, this.gameObject.transform.position);
            if (objectType == ObjectType.Turret)
            {
                GetComponent<turretScript>().HpLost();
            }
            Instantiate(Explosion, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            
        }
        else if (objectType == ObjectType.Player && healthBar != null)
            {
                healthBar.SetHealth(hp);
            }
    }

    public void Heal(int healAmount)
    {
        hp += healAmount;
        Debug.Log("Health increased by " + healAmount + ", current health is " + hp);
        hp = Mathf.Min(hp, maxHp); 
    }

    void PlayExplosionSound()
    {
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound); 
        }
    }
}
