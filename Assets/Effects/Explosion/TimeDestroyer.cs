using UnityEngine;
using System.Collections;

public class TimeDestroyer : MonoBehaviour
{

    //переменная для длительности нахождения в сцене
    public float timeToDestroy;

    //выполнится один раз при старте скрипта
    void Start()
    {
        //унитожить объект через заданное время
        Destroy(gameObject, timeToDestroy);
    }
}