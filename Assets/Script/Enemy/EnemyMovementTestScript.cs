using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovementTestScript : MonoBehaviour
{
    private Transform targetPos;
    public float detectionRange = 10f;
    public GameObject exclamationMark;

    public bool animationPlayed = false;
    public bool isInRange = false;
    public bool isInFight = false;
    NavMeshAgent agent;
    public LayerMask playerLayer;
    private Rigidbody2D rb;

    //Settings for the wandering attribute of an ennemy
    public float wanderSpeed = 1.5f;

    // Time for changing direction
    public float wanderChangeInterval = 2f;

    //Array to manage the availables mouvements of the enemy
    public Vector2[] availableMouvements = new Vector2[]{Vector2.up, Vector2.right,Vector2.down,Vector2.left};

    //Used to check if the ennemy is hitting a wall;
    public bool hittingWall;
    public Vector2 lastDirection;
    private Vector2 wanderDirection;
    private float wanderTimer = 0f;
    public MovementType movementType;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Manage collision, it's ugly rn but i'll redo it later
        if(collision.gameObject.tag == "Obstacles" 
        || collision.gameObject.tag == "Corner" 
        || collision.gameObject.tag == "DoorN" 
        || collision.gameObject.tag == "DoorS" 
        || collision.gameObject.tag == "DoorE" 
        || collision.gameObject.tag == "DoorW" )
        {
            Debug.Log("Collision");
            lastDirection = wanderDirection;
            
            while(lastDirection == wanderDirection)
            {
                SetRandomWanderDirection();
                //Debug.Log("New direction = " + wanderDirection);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerator coroutine;
        CheckPlayerInRange();
        if (isInRange || isInFight)
        {
            if (!isInFight && !animationPlayed)
            {
                StartCoroutine(PlayerFoundAnimation());
                
            }
            if (animationPlayed)
            {
                switch (movementType)
                {
                    case MovementType.Linear :
                        //todo
                        break;
                    case MovementType.LinearSlowing :
                        rb.linearVelocity = Vector2.zero;
                        rb.linearVelocity = new Vector2(targetPos.position.x - gameObject.transform.position.x,targetPos.position.y - gameObject.transform.position.y) * movementSpeed;
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
        wanderDirection = availableMouvements[Random.Range(0,(availableMouvements.Length - 1))];
        
        // Setting the wanderTimer
        wanderTimer = wanderChangeInterval;
    }

    IEnumerator PlayerFoundAnimation()
    {
        exclamationMark.SetActive(true);
        yield return new WaitForSeconds(1); // Wait for 1 second
        Destroy(exclamationMark);
        animationPlayed = true;
            
    }

    //Used for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}