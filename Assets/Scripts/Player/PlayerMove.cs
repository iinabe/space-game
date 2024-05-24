using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleUIInput : MonoBehaviour
{
    private Vector2 moveVector;
    private GameSettings gameSettings;
    private float originalMoveSpeed; 

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        originalMoveSpeed = gameSettings.movements.PlayerSpeed; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        moveVector.y = Mathf.Clamp(moveVector.y, -1.0f, 1.0f);
        MovePlayer(moveVector);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, direction.y, 0f) * gameSettings.movements.PlayerSpeed * Time.deltaTime; 
        transform.Translate(movement, Space.World);

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.1f, 0.9f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }

    public void SlowDown(float factor, float duration)
    {
        StartCoroutine(SlowDownCoroutine(factor, duration));
    }

    private IEnumerator SlowDownCoroutine(float factor, float duration)
    {
        float newMoveSpeed = originalMoveSpeed * factor; 
        gameSettings.movements.PlayerSpeed = newMoveSpeed; 

        yield return new WaitForSeconds(duration);

        gameSettings.movements.PlayerSpeed = originalMoveSpeed; 
    }
}
