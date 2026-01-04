using UnityEngine;

public class enemy_frontLineAttack : MonoBehaviour
{

    public GameObject ennemy;
    public GameObject slash;
    public LayerMask playerLayer;

    public float delayBetweenSlashes;
    public float attackRange;

    // public Rigidbody2D slashRigidBody;
    Vector2 gunDirection;
    void Start()
    {
        InvokeRepeating(nameof(Slash), 2, delayBetweenSlashes);
        gunDirection = transform.position - ennemy.transform.position;
    }

    public void Slash()
    {

            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
            if (hitPlayers.Length > 0)
            {
                // Showing the attack
                GameObject newSlash = Instantiate(slash, transform.position, Quaternion.identity);
                newSlash.transform.SetParent(transform);
                newSlash.transform.localPosition = Vector3.zero;
                //Manage the rotation of the attack
                float angle = 0f;
                // Top attack
                if (gunDirection.y == 1.5) angle = -90f;
                // Left attack
                else if (gunDirection.x == -1.25) angle =  0f;
                // Down attack
                else if (gunDirection.y == -1.5) angle = 90f;
                // Right attack
                else if (gunDirection.x == 1.25) angle = 180f;
                //Rotate the Melee depending on the roation
                newSlash.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
    }
}
