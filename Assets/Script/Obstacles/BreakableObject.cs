using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public float maxHealthPoint;
    public float damageReceived;
    public Sprite spriteTwoHP;
    public Sprite spriteOneHP;

    SpriteRenderer spriteRenderer;
    float currentHealthPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealthPoint = maxHealthPoint;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Detected");
        if (collision.CompareTag("PlayerAttack"))
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        Debug.Log("Taking damages");
        currentHealthPoint = currentHealthPoint - damageReceived;
        if(currentHealthPoint == 2)
        {
            spriteRenderer.sprite = spriteTwoHP;
        }
        else if(currentHealthPoint == 1)
        {
            spriteRenderer.sprite = spriteOneHP;
        }
         else if(currentHealthPoint == 0)
        {
            Destroy(gameObject);
        }
    }
}
