using System;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    // Player weapon
    public GameObject Melee;

    //Player movement
    PlayerMovementScript playerMovement;

    //Check if the player is attacking, used to add a timer
    bool isAttacking = false;

    //Values of the attack of the player. 
    public float atkDuration = 0.3f;
    public float atkTimer = 0f;
    public float aimRadius = 1f;

    // The enemy layer, needs to be set in the Unity Inspector
    public LayerMask enemyLayer;

    // Visual and practical offset for the attack, on each direction. Default offset is .5f
    public Vector3 attackUpOffset = new Vector3(0, 0.2f, 0);
    public Vector3 attackDownOffset = new Vector3(0, -0.2f, 0);
    public Vector3 attackLeftOffset = new Vector3(-0.2f, 0, 0);
    public Vector3 attackRightOffset = new Vector3(0.2f, 0, 0);

    // Adding the slash animation
    public Animator meleeAnimator;
    public float swingAngle = 120f;
    private float currentSwingTime = 0f;
    private Quaternion startRot;
    private Quaternion endRot;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
    }


    void Update()
    {
        //First, I check the melee timer to see if I can attack
        CheckMeleeTimer();

        // If you are not attacking already
        if (!isAttacking)
        {
            /* Get the input on your keyboard
            * Note : On my keyboard, its WASD, we'll change it later
            */
            if (Input.GetKey(KeyCode.S))
            {
                switch (playerMovement.GetPlayerDirection())
            {
                case PlayerDirection.up:
                    OnAttack(Vector3.up, attackUpOffset);
                    break;
                case PlayerDirection.down:
                    OnAttack(Vector3.down, attackDownOffset);
                    break;
                case PlayerDirection.left:
                    OnAttack(Vector3.left, attackLeftOffset);
                    break;
                case PlayerDirection.right:
                    OnAttack(Vector3.right, attackRightOffset);
                    break;
            }
            }
        }
    }
    void OnAttack(Vector3 direction, Vector3 offset)
    {
        // Finding Enemies
        isAttacking = true;
        atkTimer = 0f; // reset timer for this attack

        /*
        * When Attacking, I get every enemy in the radius of my attack.
        * This radius is larger than the actual size of the attack to add a magnetic effect on the attack
        */
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + offset, aimRadius, enemyLayer);
        Vector3 aimPosition = transform.position + offset;
        Debug.Log("Number of enemies : " + hits.Length);
        if (hits.Length > 0) {
            /* We check whick enemy is the closest of the player
            * If there are 2 enemies, the closest one will be the one on which you'll get magnetized
            */
            float closestDistance = Mathf.Infinity;
            Collider2D closestEnemy = null;
            foreach (var hit in hits)
            {
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist < closestDistance) { 
                closestDistance = dist;
                    closestEnemy = hit;
                }
            }
            if (closestEnemy != null) { 
                // The aimPosition is the position of the enemy
                aimPosition = closestEnemy.transform.position;
            }
        }
        //Show the melee animation or the melee sprite
        Melee.SetActive(true);
        //Set the melee position to the aim
        Melee.transform.position = aimPosition;
        Melee.transform.localPosition = offset;

        // Manage the rotation of the attack (FIXED, no arc)
        float angle = 0f;
        if (direction == Vector3.up) angle = 90f;
        else if (direction == Vector3.down) angle = -90f;
        else if (direction == Vector3.left) angle = 180f;
        else if (direction == Vector3.right) angle = 0f;

        //Rotate the Melee depending on the direction
        Melee.transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Play the slash animation
        if (meleeAnimator != null)
        {
            meleeAnimator.Play("Slash", 0, 0f);
        }
    }
    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            // Starting the time
            atkTimer += Time.deltaTime;
            float t = Mathf.Clamp01(atkTimer / atkDuration);
            if (atkTimer > atkDuration)
            {
                // The attack ends
                atkTimer = 0;
                isAttacking = false;
                Melee.SetActive(false);
                Melee.transform.localPosition = Vector3.zero;
            }
        }
    }

}
