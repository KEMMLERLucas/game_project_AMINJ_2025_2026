using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
    //Damage of the weapon
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We get every enemy with the "EnemyBehaviourScript"
        //Must be replaced with GameObject.FindWithTag("Enemy").transform;
        EnemyBehaviourScript enemy = collision.GetComponent<EnemyBehaviourScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else
        {
           //Not an enemy
        }
    }

}
