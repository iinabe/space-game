using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    //переменная для позиции клика
    Vector3 clickPos;
    //переменная для вектора движения
    Vector3 move;
    //переменная для скорости движения
    public float speed = 1;
    //переменная для ссылки на Rigidbody2D
    Rigidbody2D rb;

    //выполнится один раз при старте скрипта
    void Start()
    {
        //делаем ссылку на компонент Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        //что-бы корабль остался на месте и не полетел к точке (0,0,0)
        clickPos = transform.position;
    }

    //исполняется каждый новый кадр
    void Update()
    {
        //проверка, нажата-ли левая кнопка мыши
        if (Input.GetMouseButton(0))
        {
            //трансформировать координаты курсора в координаты игрового мира
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //вычислить новый вектор движения
        move = clickPos - transform.position;
    }

    //выполняется через определенные периоды (0.02 по умолчанию). Используйте для вычислений физики
    void FixedUpdate()
    {
        //измените вектор движения
        //z останется 0, что-бы корабль не двигался по z-оси
        rb.velocity = new Vector2(move.x, move.y) * speed;
    }
}