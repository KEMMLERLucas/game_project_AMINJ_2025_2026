using UnityEngine;

public class BossStatistics : MonoBehaviour
{
    public float maxHealthPoint;
    public float damageReceived;
    public SpriteRenderer sr;

    float currentHealthPoint;
    Animator anim;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        currentHealthPoint = maxHealthPoint;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHealthPoint -= damageReceived;
        Debug.Log("Taking dmg");
        if (anim != null)
        {
            anim.SetTrigger("Hit");
        }

        if (currentHealthPoint <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
