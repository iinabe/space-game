using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    //переменная для ссылки на префаб лазера
    public GameObject laser;
    //задержка между выстрелами
    public float delayTime;
    //бинарная переменная для проверки возможности стрельбы
    bool canShoot = true;

    //выполняется каждый кадр
    void Update()
    {
        //проверка: нажата-ли правая кнопка и можно-ли стрелять
        if (canShoot && Input.GetMouseButton(1))
        {
            //отключить возможность стрельбы для следующей проверки
            canShoot = false;
            //спавн лазера на позиции корабля
            Instantiate(laser, transform.position, transform.rotation);
            //запуск функции дающей разрешение на стрельбу
            StartCoroutine(NoFire());
        }
    }

    //корутина, такую функцию можно поставить на паузу
    IEnumerator NoFire()
    {
        //пауза этой функции, возврат через заданное время
        yield return new WaitForSeconds(delayTime);
        //влючить возможность стрельбы
        canShoot = true;
    }
}
