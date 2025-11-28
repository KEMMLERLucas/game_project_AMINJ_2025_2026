using UnityEngine;

public class EnemyAttackingPlayerScript : MonoBehaviour
{
    // Attack management
    public GameObject milkBottle; 

    public int attackDamage = 1;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int projectileCount = 3;

    // MouvementDirection
    private Transform targetPos;
    private Vector2 lastMoveDirection = Vector2.right;
    
    public Transform attackTransform;

    // Attack Type
    AttackType attackType;

    // Range management
    public float coneAngle = 3f;
    public int rayCount = 5;

    // Others
    private LayerMask playerLayer;
    private RaycastHit2D hit;
    private bool drawGizmos = false;
    private float nextAttackTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = GameObject.FindWithTag("Player").transform;
        if (milkBottle != null) milkBottle.SetActive(false);
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
    void Attack(GameObject player)
    {
        if (HealthScript.instance != null)
        {
            HealthScript.instance.TakingDamage();
        }
    }
    void CheckForPlayerCloseRange()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        if (hitPlayers.Length > 0)
        {
            Attack_CloseRange(hitPlayers[0].gameObject);
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack_CloseRange(GameObject player)
    {
        if (milkBottle != null) milkBottle.SetActive(true);
        Vector3 dir = (player.transform.position - milkBottle.transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        milkBottle.transform.rotation = Quaternion.Euler(0, 0, angle);

        HealthScript.instance.TakingDamage();
        StartCoroutine(HideMilkBottleAfterDelay(0.4f));
    }

    System.Collections.IEnumerator HideMilkBottleAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        if (milkBottle != null) milkBottle.SetActive(false);
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
