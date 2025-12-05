using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthScript healthBarScript;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.CompareTag("EnemyAttack"))
        {
            healthBarScript.TakingDamage();
        }

        if (collision.CompareTag("HealthPickup"))
        {
            healthBarScript.Healing();
        }
    }
}
