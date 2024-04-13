using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick;

    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        float horizontalMovement = horizontalInput * speed * Time.deltaTime;
        float verticalMovement = verticalInput * speed * Time.deltaTime;

        transform.Translate(new Vector3(horizontalMovement, verticalMovement, 0));
    }
}
