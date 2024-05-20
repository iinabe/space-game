using UnityEngine;

public class HpController : MonoBehaviour
{
    public enum ObjectType { Player, Asteroid, Turret }

    public ObjectType objectType;
    private int hp;
    private int maxHp = 100;


    public AudioClip explosionSound;
    private AudioSource audioSource;

    public GameObject Explosion;
    public HealthBar healthBar;

    [SerializeField] private ShipArmorController _armor;

    private void Start()
    {
        switch (objectType)
        {
            case ObjectType.Player:
                hp = maxHp;
                if (healthBar != null)
                {
                    healthBar.SetMaxHealth(maxHp);
                    healthBar.SetHealth(hp);
                }
                break;
            case ObjectType.Asteroid:
                hp = 3;
                break;
            case ObjectType.Turret:
                hp = 3;
                break;
            default:
                hp = maxHp;
                break;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void MakeDamage(int damage)
    {
        // Если есть броня, урон сначала уменьшает броню

		if (IsHaveArmor())
		{
			damage = _armor.TryDamage(damage);
		}

        // Если урон остаётся после уменьшения брони, он уменьшает здоровье
        if (damage > 0)
        {         
            hp -= damage;
        }

        // Обновляем полоску здоровья
        if (objectType == ObjectType.Player && healthBar != null)
        {
            healthBar.SetHealth(hp);
        }

        // Проверяем, умер ли объект
        if (hp <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSound, this.gameObject.transform.position);
            if (objectType == ObjectType.Turret)
            {
                GetComponent<turretScript>().HpLost();
            }
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

	private bool IsHaveArmor() => _armor != null;

    public void Heal(int healAmount)
    {
        hp += healAmount;
        hp = Mathf.Min(hp, maxHp);
        if (healthBar != null)
        {
            healthBar.SetHealth(hp);
        }
        Debug.Log("Здоровье увеличено на " + healAmount + ", текущее здоровье: " + hp);
    }

    void PlayExplosionSound()
    {
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
