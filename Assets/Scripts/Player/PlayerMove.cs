using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleUIInput : MonoBehaviour
{
    private Vector2 moveVector;
    public float moveSpeed;
    private float originalMoveSpeed;

    private void Start()
    {
        originalMoveSpeed = moveSpeed;
        Debug.Log("Initial moveSpeed: " + moveSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        moveVector.y = Mathf.Clamp(moveVector.y, -1.0f, 1.0f);
    }

    private void Update()
    {
        MovePlayer(moveVector);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, direction.y, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.1f, 0.9f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.1f, 0.9f); 
        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);

        Debug.Log("Player moved with speed: " + moveSpeed);
    }

    public void SlowDown(float factor, float duration)
    {
        Debug.Log("SlowDown called with factor: " + factor + " and duration: " + duration);
        StartCoroutine(SlowDownCoroutine(factor, duration));
    }

    private IEnumerator SlowDownCoroutine(float factor, float duration)
    {
        float newMoveSpeed = originalMoveSpeed * factor;
        Debug.Log("Player speed will be reduced to: " + newMoveSpeed);
        moveSpeed = newMoveSpeed;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalMoveSpeed;
        Debug.Log("Player speed restored to: " + originalMoveSpeed);
    }
}
