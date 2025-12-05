using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NumberOfKeyScript.instance.CollectKey();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "BossDoor")
        {
            NumberOfKeyScript.instance.UseKey();

            // Add animation or thing that shows that the door is open here
        }
    }
}
