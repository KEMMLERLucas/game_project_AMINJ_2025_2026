using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviourScript enemy = collision.GetComponent<EnemyBehaviourScript>();
        if (enemy != null)
        {
            Debug.Log("Collision avec ennemi détectée, application de dégâts : " + damage);
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Collision détectée mais pas un ennemi : " + collision.gameObject.name);
        }
    }

}
