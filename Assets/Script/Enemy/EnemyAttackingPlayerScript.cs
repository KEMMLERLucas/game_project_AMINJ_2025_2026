using UnityEngine;

public class EnemyAttackingPlayerScript : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private int attackDamage = 1;

    [SerializeField] private LayerMask playerLayer;
    
    private float nextAttackTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            CheckForPlayer();
        }
    }
    void CheckForPlayer()
    {
        Debug.Log("Layer: " + playerLayer);
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        Debug.Log("Joueurs trouvés: " + hitPlayers);
        if (hitPlayers.Length > 0)
        {
            Attack(hitPlayers[0].gameObject);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    void Attack(GameObject player)
    {
        Debug.Log("Attaque: " + player.name);
        PlayerHealthScript playerHealth = player.GetComponent<PlayerHealthScript>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
