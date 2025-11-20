using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementTestScript : MonoBehaviour
{
    private Transform targetPos;
    public float detectionRange = 10f;
    public bool isInRange = false;
    NavMeshAgent agent;
    public LayerMask playerLayer;
    private Rigidbody2D rb;
    //Settings for the wandering attribute of an ennemy
    public float wanderSpeed = 1.5f;
    // Time for changing direction
    public float wanderChangeInterval = 2f;

    private Vector2 wanderDirection;
    private float wanderTimer = 0f;
    public enum MovementType
    {
        Linear,
        LinearSlowing,
        PathFindingLinear,
        PathFindingLinearSlowing
    }

    public MovementType movementType = MovementType.LinearSlowing;
    public float movementSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;


    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInRange();
        if (isInRange)
        {
            switch (movementType){
            case MovementType.Linear :
                //todo
                break;
            case MovementType.LinearSlowing :
                rb.linearVelocity = Vector2.zero;
                rb.linearVelocity = new Vector2(
                targetPos.position.x - gameObject.transform.position.x,
                targetPos.position.y - gameObject.transform.position.y
                ) * movementSpeed;
                break;
            case MovementType.PathFindingLinear : 
                agent.SetDestination(targetPos.position);
                //todo
                break;
            case MovementType.PathFindingLinearSlowing :
                //todo
                break;
 
            }
        }
        else
        {
            Wander();
        }
        
    }
    void CheckPlayerInRange()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, detectionRange, playerLayer);
        isInRange = hitPlayers.Length > 0;
    }
    void Wander()
    {
        // Setting base time
        wanderTimer -= Time.deltaTime;

        // Selecting direction
        if (wanderTimer <= 0f)
        {
            SetRandomWanderDirection();
        }

        // Moving
        rb.linearVelocity = wanderDirection * wanderSpeed;
    }
    void SetRandomWanderDirection()
    {
        // Setting the random direction
        wanderDirection = Random.insideUnitCircle.normalized;
        // Setting the wanderTimer
        wanderTimer = wanderChangeInterval;
    }

    //Used for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}