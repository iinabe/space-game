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
        // Получаем направление движения с джойстика
        moveVector = context.ReadValue<Vector2>();

        // Устанавливаем вертикальную составляющую движения
        moveVector.y = Mathf.Clamp(moveVector.y, -1.0f, 1.0f);

        // Двигаем персонажа
        MovePlayer(moveVector);
    }

    private void MovePlayer(Vector2 direction)
    {
        // Создаем вектор движения
        Vector3 movement = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.deltaTime;

        // Применяем движение к персонажу
        transform.Translate(movement, Space.World);
    }
}