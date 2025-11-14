using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 6;
    private int currentHealth;
    public GameManagerScript GameManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("EnemyAttack"))
        {
            GameManager.TakeDamage(1);
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort!");
        Destroy(gameObject);
    }
}
