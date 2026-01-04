using UnityEngine;

public class DartScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
            return;
        Destroy(gameObject);
    }
}
