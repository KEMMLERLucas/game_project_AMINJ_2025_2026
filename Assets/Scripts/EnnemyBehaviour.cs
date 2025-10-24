using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float healthPoint;
    private float damage;
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
     * public void OnCollisionEnted2D(Collision2D collision){
     *  if(collision.collider.CompareTag("Enemy)){
     *      gameManagement.TakeDamage(0.5f);
     *  }
     * }
     */



    private void TakeDamage(float damage)
    {
        healthPoint -= damage;
        if (healthPoint <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}