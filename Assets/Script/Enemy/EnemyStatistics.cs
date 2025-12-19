using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float maxHealthPoint;
    public float damageReceived;
    public SpriteRenderer sr;
    float currentHealthPoint;

    void Start()
    {
        sr=gameObject.GetComponent<SpriteRenderer>();
        currentHealthPoint = maxHealthPoint;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage();
        }

    }
    public void TakeDamage()
    {
        currentHealthPoint = currentHealthPoint - damageReceived;
        sr.enabled = false;     
        sr.enabled = true;  
        if (currentHealthPoint <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}