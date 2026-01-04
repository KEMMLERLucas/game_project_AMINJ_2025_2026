using UnityEngine;

public class Boss_RangeAttack : MonoBehaviour
{
    public GameObject ennemy;
    public GameObject dart;
    public float delayBetweenShots = 1f;
    public float dartSpeed = 5f;

    // angle d'écart entre les projectiles en degrés
    public float spreadAngle = 15f; 

    Vector2 gunDirection;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 2f, delayBetweenShots);
        gunDirection = (transform.position - ennemy.transform.position).normalized;
    }

    public void Shoot()
    {
        if (!gameObject.activeSelf) return;

        // direction de base
        Vector2 baseDir = gunDirection.normalized;

        // angle de base
        float baseAngle = Mathf.Atan2(baseDir.y, baseDir.x) * Mathf.Rad2Deg;

        // trois angles : centre, gauche, droite
        float[] angles = new float[]
        {
            baseAngle,                 // centre
            baseAngle + spreadAngle,   // droite
            baseAngle - spreadAngle    // gauche
        };

        for (int i = 0; i < angles.Length; i++)
        {
            float rad = angles[i] * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;

            GameObject newDart = Instantiate(dart, transform.position, Quaternion.identity);
            Rigidbody2D rb = newDart.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = dir * dartSpeed;
        }
    }
}
