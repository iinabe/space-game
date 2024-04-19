using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidDamage : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Asteroid collided with player!");
            HpController hpController = other.gameObject.GetComponent<HpController>();
            if (hpController != null)
            {
                hpController.MakeDamage(damage); 
            }
            else 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Destroy(gameObject);
        }
    } 

}
