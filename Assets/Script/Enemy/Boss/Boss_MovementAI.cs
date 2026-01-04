using UnityEngine;
using UnityEngine.AI;

public class BossMovementAI : MonoBehaviour
{
    public enum MoveState { RangedMove, MovingToMelee }
    public MoveState currentState = MoveState.RangedMove;

    public BossAttackAI attackAI;
    private Rigidbody2D rb;
    private NavMeshAgent agent;

    public string playerTag = "Player";

    public float rangedMoveSpeed = 3f;
    public float preferredRangedDistance = 5f;
    public float meleeRange = 1.2f;
    public float meleeSpeed = 3f;

    Transform player;

    void Start()
    {
        Debug.Log("BossMovementAI Start()");
        rb = GetComponent<Rigidbody2D>();

        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgentMissing " + gameObject.name);
            return;
        }

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        FindPlayerByTag();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayerByTag();
            return;
        }

        switch (currentState)
        {
            case MoveState.RangedMove:
                HandleRangedMove();
                break;
            case MoveState.MovingToMelee:
                HandleMoveToMelee();
                break;
        }
    }

    void FindPlayerByTag()
    {
        GameObject target = GameObject.FindWithTag(playerTag);
        if (target != null)
            player = target.transform;
    }

    void HandleRangedMove()
    {
        if (agent == null || player == null) return;

        if (attackAI != null)
            attackAI.SetRangedMode();

        Vector3 toPlayer = player.position - transform.position;
        float distance = toPlayer.magnitude;
        Vector3 dir = toPlayer.normalized;

        Vector3 targetPos = transform.position;

        if (distance > preferredRangedDistance + 0.5f)
        {
            targetPos = player.position;             
        }
        else if (distance < preferredRangedDistance - 0.5f)
        {
            targetPos = transform.position - dir * 2f; 
        }
        else
        {
            agent.ResetPath();
            return;
        }

        agent.speed = rangedMoveSpeed;
        agent.SetDestination(targetPos);
    }

    public void StartMeleePhase()
    {
        if (agent == null || player == null) return;

        Debug.Log("BossMovementAI.StartMeleePhase(): passing to MovingToMelee");

        currentState = MoveState.MovingToMelee;

        if (attackAI != null)
            attackAI.SetMeleeMode();

        agent.speed = meleeSpeed;
        agent.SetDestination(player.position);
    }

   void HandleMoveToMelee()
{
    if (agent == null || player == null) return;

    agent.speed = meleeSpeed;
    agent.SetDestination(player.position);

    float distance = Vector3.Distance(transform.position, player.position);

}


    public void GoBackToRanged()
    {
        currentState = MoveState.RangedMove;
        if (attackAI != null)
            attackAI.SetRangedMode();
    }
}
