using UnityEngine;

public class PlayerAttackDistanceScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float shootTimer;
    PlayerMovementScript playerMovement;
    bool canShoot;
    bool canDistanceAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovementScript>();
        canShoot = true;
        canDistanceAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && canShoot && canDistanceAttack)
        {
            // Instantiate a new bullet
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 bulletDirection = Vector3.zero;

            // Direction of the bullet
            switch (playerMovement.GetPlayerDirection())
            {
                case PlayerDirection.up:
                    bulletDirection = Vector3.up;
                    break;
                case PlayerDirection.down:
                    bulletDirection = Vector3.down;
                    break;
                case PlayerDirection.left:
                    bulletDirection = Vector3.left;
                    break;
                case PlayerDirection.right:
                    bulletDirection = Vector3.right;
                    break;
            }
            newBullet.GetComponent<Rigidbody2D>().linearVelocity = bulletDirection * bulletSpeed;
            canShoot = false;

            // Set timer for a new bullet
            Invoke("Shoot", shootTimer);
        }
    }

    public void Shoot()
    {
        if (!canShoot)
        {
            canShoot = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canDistanceAttack && collision.gameObject.tag == "PowerUp")
        {
            canDistanceAttack = true;
        }
    }
}