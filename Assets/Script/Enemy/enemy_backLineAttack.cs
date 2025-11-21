using UnityEngine;

public class enemy_backLineAttack : MonoBehaviour
{

    public GameObject ennemy;
    public GameObject dart;
    public float delayBetweenShots;
    public float dartSpeed;
    public Rigidbody2D dartRigidBody;
    Vector2 gunDirection;
    void Start()
    {
        InvokeRepeating(nameof(Shoot), 2, delayBetweenShots);
        gunDirection = transform.position - ennemy.transform.position;
    }

    public void Shoot()
    {
        if (gameObject.activeSelf)
        {
            GameObject newDart = Instantiate(dart, transform.position, Quaternion.identity);
            newDart.GetComponent<Rigidbody2D>().linearVelocity = gunDirection * dartSpeed;
        }
        
    }
}
