using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public float healthPoint;
    public float damage;
    void Start()
    {

    }
    // Add a function to manage the damage of the attack
    public void OnTriggerEnter2D(Collider2D collision)
    {

        /*if (collision.CompareTag("FriendlyAttack"){// Must put the name of the attack for interaction between player and ennemy
            TakeDamage(collision.GetComponent<Attack>().GetDamage);
        }*/
    }

    // In main character mouvement, add a colision function to manage the damage of the ennemy
    /*
     * The function : 
     * public void OnCollisionEntered2D(Collision2D collision){
     *  if(collision.collider.CompareTag("Enemy)){
     *      gameManagement.TakeDamage(0.5f);
     *  }
     * }
     */



    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            Die();
        }
    }
    public void Die()
             {
                 Destroy(gameObject);
             }

}