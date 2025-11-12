using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 6;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Joueur a pris {damage} dégâts. Santé: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("DamagingObstacle"))
        {
            TakeDamage(1);
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort!");
        Destroy(gameObject);
    }
}
