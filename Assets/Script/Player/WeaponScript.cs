using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviourScript enemy = collision.GetComponent<EnemyBehaviourScript>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
