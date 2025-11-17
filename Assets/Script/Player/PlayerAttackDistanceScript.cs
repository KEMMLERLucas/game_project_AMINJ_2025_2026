using UnityEngine;

public class PlayerAttackDistanceScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
   // public SpriteRenderer currentCatSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  currentCatSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector3.up * bulletSpeed;
        }
    }
}
