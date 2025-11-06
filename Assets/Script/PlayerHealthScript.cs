using UnityEngine;

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

    void Die()
    {
        Debug.Log("Le joueur est mort!");
    }
}
