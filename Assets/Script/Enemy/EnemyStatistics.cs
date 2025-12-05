using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public float maxHealthPoint;
    public float damageReceived;
    float currentHealthPoint;

    void Start()
    {
        currentHealthPoint = maxHealthPoint;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage();
        }

        //if (collision.CompareTag("FriendlyAttack")
        //{ TakeDamage(collision.GetComponent<Attack>().GetDamage); }
    }
    public void TakeDamage()
    {
        currentHealthPoint = currentHealthPoint - damageReceived;
        Debug.Log("current health" + currentHealthPoint); 

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