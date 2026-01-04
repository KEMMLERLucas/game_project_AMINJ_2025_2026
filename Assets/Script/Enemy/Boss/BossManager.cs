using UnityEngine;

public class BossManager : MonoBehaviour
{
    [Header("Références")]
    public BossMovementAI movementAI;
    public BossAttackAI attackAI;

    [Header("Phases")]
    public float timeBetweenPhases = 10f;    // durée d'une phase distance avant de passer cac
    public float meleePhaseDuration = 5f;    // durée max d'une phase cac

    public float cooldownBetweenMelee = 3f;  // pause après la phase cac avant de pouvoir relancer une phase cac

    enum BossPhase { Ranged, Melee, Cooldown }
    BossPhase currentPhase = BossPhase.Ranged;

    float phaseTimer;

    void Start()
    {
        if (movementAI == null)
            movementAI = GetComponent<BossMovementAI>();

        if (attackAI == null)
            attackAI = GetComponent<BossAttackAI>();

        if (attackAI != null)
            attackAI.SetRangedMode();
    }

    void Update()
    {
        phaseTimer += Time.deltaTime;

        switch (currentPhase)
        {
            case BossPhase.Ranged:
                HandleRangedPhase();
                break;
            case BossPhase.Melee:
                HandleMeleePhase();
                break;
            case BossPhase.Cooldown:
                HandleCooldownPhase();
                break;
        }
    }

    void HandleRangedPhase()
    {
        if (phaseTimer >= timeBetweenPhases)
        {
            phaseTimer = 0f;
            StartMeleePhase();
        }
    }

    void HandleMeleePhase()
    {
        if (phaseTimer >= meleePhaseDuration)
        {
            phaseTimer = 0f;
            GoToCooldown();
        }
    }

    void HandleCooldownPhase()
    {
        if (phaseTimer >= cooldownBetweenMelee)
        {
            phaseTimer = 0f;
            currentPhase = BossPhase.Ranged;
        }
    }

    void StartMeleePhase()
    {
        Debug.Log("Starting melee phase");
        currentPhase = BossPhase.Melee;
        if (movementAI != null)
            movementAI.StartMeleePhase();
    }

    void GoToCooldown()
    {
        currentPhase = BossPhase.Cooldown;
        if (movementAI != null)
            movementAI.GoBackToRanged();
    }

    public void StartMeleePhaseManual()
    {
        StartMeleePhase();
    }

    public void GoToRangedPhase()
    {
        currentPhase = BossPhase.Ranged;
        phaseTimer = 0f;
        if (attackAI != null)
            attackAI.SetRangedMode();
    }

    public void GoToMeleePhase()
    {
        StartMeleePhase();
    }
}
