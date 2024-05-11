using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour
{
    public float speed = 10f;
    public int damage;
    //gamesettings.damages.laserDamage;
    public Vector2 direction;
    public AudioClip explosionSound; // Звук взрыва астероида
    private AudioSource audioSource; // Компонент для воспроизведения звука

    void Start()
    {
        direction = transform.up;
        audioSource = GetComponent<AudioSource>(); // Получаем компонент AudioSource
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.SendMessage("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);
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
