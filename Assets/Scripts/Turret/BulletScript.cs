using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
