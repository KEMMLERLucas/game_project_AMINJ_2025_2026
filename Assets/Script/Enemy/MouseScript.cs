using UnityEngine;

public class MouseScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && HealthScript.instance.CanHeal())
        {
               HealthScript.instance.Healing();
               Destroy(gameObject);
        }
    }
}
