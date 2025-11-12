using UnityEngine;

public class EnemyAttackingPlayerScript : MonoBehaviour
{
    // Attack management
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private int projectileCount = 3;
    // MouvementDirection
    private Transform targetPos;
    private Vector2 lastMoveDirection = Vector2.right;
    
    [SerializeField] private Transform attackTransform;
    // Attack Type
    public enum AttackType
    {
        closeRange,
        closeRangeCharge,
        longRangeCone,
        longRangeAll,
        longRangeStun
    }
    [SerializeField] AttackType attackType;

    //Range management
    [SerializeField] private float coneAngle = 3f;
    [SerializeField] int rayCount = 5;
    

    // Others
    [SerializeField] private LayerMask playerLayer;
    private RaycastHit2D hit;
    private bool drawGizmos = false;
    private float nextAttackTime = 0f;
    void Start()
    {
        targetPos = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            switch (attackType)
            {
                case AttackType.closeRange:
                    CheckForPlayerCloseRange();
                    break;
                case AttackType.closeRangeCharge:
                    break;
                case AttackType.longRangeCone:
                    CheckForPlayerLongRangeCone();
                    break;
                case AttackType.longRangeAll:
                    CheckForPlayerRange();
                    break;
                case AttackType.longRangeStun:
                    break; 
            }
            CheckForPlayerRange();
        }
    }
    void CheckForPlayerRange()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        if (hitPlayers.Length > 0)
        {
            Attack(hitPlayers[0].gameObject);
            nextAttackTime = Time.time + attackCooldown;
        }
        
    }
    void CheckForPlayerCloseRange()
    {
        //Get current angle of the ennemy
        Vector2 moveOrientation = new Vector2(
                targetPos.position.x - gameObject.transform.position.x,
                targetPos.position.y - gameObject.transform.position.y
                );

        lastMoveDirection = moveOrientation.normalized;
        float angle = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg;
        
        //Start angle of the cone
        float startAngle = -angle / 2f;
        float angleStep = angle / (rayCount - 1); 
        
        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);
            Vector2 direction = Quaternion.Euler(0, 0, currentAngle) * transform.right;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackRange);
            if (hit.collider != null)
            {
                Attack(hit.collider.gameObject);
            }
        }
    }
    void CheckForPlayerLongRangeCone()
    {
        /**float startAngle = -coneAngle / 2f;
        float angleStep = coneAngle / (rayCount - 1);
        //Temp to manage the "shotgun" like attack
        for (int i = 0; i < projectileCount; i++)
        {
            Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, aimAngle);
            GameObject projectile = Instantiate(/*projectilePrefab, transform.position, rotation);
            aimAngle -= angleStep;
        }*/
    }
    void Attack(GameObject player)
    {
        PlayerHealthScript playerHealth = player.GetComponent<PlayerHealthScript>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
{
    if (!drawGizmos) return;

    switch (attackType)
    {
        case AttackType.closeRange:
            Gizmos.color = Color.yellow;
            GameObject player = GameObject.FindWithTag("Player");
            if (player == null) return;

            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            float angleToPlayer = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

            float startAngle = angleToPlayer - (coneAngle / 2f);
            float endAngle = angleToPlayer + (coneAngle / 2f);
            Vector3 leftBoundary = new Vector3(Mathf.Cos(startAngle * Mathf.Deg2Rad), Mathf.Sin(startAngle * Mathf.Deg2Rad), 0);
            Vector3 rightBoundary = new Vector3(Mathf.Cos(endAngle * Mathf.Deg2Rad), Mathf.Sin(endAngle * Mathf.Deg2Rad), 0);

            Gizmos.DrawLine(transform.position, transform.position + leftBoundary * attackRange);
            Gizmos.DrawLine(transform.position, transform.position + rightBoundary * attackRange);

            Gizmos.DrawWireSphere(transform.position, attackRange);

            break;

        
    }
}

}
