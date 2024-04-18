using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleUIInput : MonoBehaviour
{
    private Vector2 moveVector;
    public float moveSpeed;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.position += moveVector.x * moveSpeed * Time.fixedDeltaTime * transform.right +
              moveVector.y * moveSpeed * Time.fixedDeltaTime * transform.forward;
    }

}

