using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_backLineMovementAI : MonoBehaviour
{
    public bool movesVertically;
    public float movementSpeed;
    public float wallOffsetMaxY;
    public float wallOffsetMinY;
    public float wallOffsetMaxX;
    public float wallOffSetMinX;
    Vector2 velocity;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (movesVertically == true)
        {
            rigidbody2D.linearVelocity = movementSpeed * Vector2.up;
        }

        else
        {
            rigidbody2D.linearVelocity = movementSpeed * Vector2.right;
        }

        velocity = rigidbody2D.linearVelocity;
    }

    void Update()
    {
        if (movesVertically == true && transform.position.y >= wallOffsetMaxY)
        {
            rigidbody2D.linearVelocity = new Vector2(-velocity.x, -velocity.y);
           
        }

        else if (movesVertically == true && transform.position.y <= wallOffsetMinY)
        {
            rigidbody2D.linearVelocity = new Vector2(-velocity.x, -velocity.y);
        }

        if (movesVertically == false && transform.position.x >= wallOffsetMaxX)
        {
            rigidbody2D.linearVelocity = new Vector2(-velocity.x, -velocity.y);
        }

        else if (movesVertically == false && transform.position.x <= wallOffSetMinX)
        {
            rigidbody2D.linearVelocity = new Vector2(-velocity.x, -velocity.y);
        }

        velocity = rigidbody2D.linearVelocity;
    }
}
