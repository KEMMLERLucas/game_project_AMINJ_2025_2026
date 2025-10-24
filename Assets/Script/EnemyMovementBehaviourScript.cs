using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementBehaviourScript : MonoBehaviour
{
    private Transform targetPos;
    NavMeshAgent agent;
    private Rigidbody2D rb;
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
}