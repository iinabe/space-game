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
        gameSettings = FindObjectOfType<GameSettings>();
        transform.up = transform.up;
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(transform.up * gameSettings.movements.LaserSpeed * Time.deltaTime);
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