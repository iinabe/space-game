using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;
    public AudioClip explosionSound; // Звук взрыва астероида
    private AudioSource audioSource; // Компонент для воспроизведения звука

    private GameSettings gameSettings;

    void Start()
    {
        direction = transform.up;
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
        gameSettings = FindObjectOfType<GameSettings>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.SendMessage("MakeDamage", gameSettings.damages.LaserDamage, SendMessageOptions.DontRequireReceiver);
            PlayExplosionSound(); // Вызываем метод для воспроизведения звука взрыва
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void PlayExplosionSound()
    {
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound); // Воспроизводим звук взрыва
        }
    }
}