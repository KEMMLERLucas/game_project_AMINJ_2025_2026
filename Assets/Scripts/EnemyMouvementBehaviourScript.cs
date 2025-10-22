using UnityEngine;

public class EnemyMouvementBehaviourScript : MonoBehaviour
{
    private Transform targetPos;
    private Rigidbody2D rb;
    public float movementSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();


        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(0, 0);
        rb.linearVelocity=new Vector2(targetPos.position.x-gameObject.transform.position.x, targetPos.position.y - gameObject.transform.position.y)*movementSpeed;
    }
}
