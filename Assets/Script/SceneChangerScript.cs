using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{

    PlayerMovement playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When the player is in Scene1
        if (SceneManager.GetActiveScene().name == "Scene1" && collision.gameObject.tag == "DoorN")
        {
            SceneManager.sceneLoaded += playerMovement.InitializeCorners;
            SceneManager.LoadScene("Scene2");
        }

        // When the player is in Scene2
        if (SceneManager.GetActiveScene().name == "Scene2" && collision.gameObject.tag == "DoorS")
        {
            SceneManager.LoadScene("Scene1");
        }
        if (SceneManager.GetActiveScene().name == "Scene2" && collision.gameObject.tag == "DoorW")
        {
            SceneManager.LoadScene("Scene3b");
        }
        if (SceneManager.GetActiveScene().name == "Scene2" && collision.gameObject.tag == "DoorE")
        {
            SceneManager.LoadScene("Scene3a");
        }

        // When the player is in Scene3a
        if (SceneManager.GetActiveScene().name == "Scene3a" && collision.gameObject.tag == "DoorE")
        {
            SceneManager.LoadScene("Scene2");
        }
        if (SceneManager.GetActiveScene().name == "Scene3a" && collision.gameObject.tag == "DoorN")
        {
            SceneManager.LoadScene("Scene4");
        }

        // When the player is in Scene3b
        if (SceneManager.GetActiveScene().name == "Scene3b" && collision.gameObject.tag == "DoorE")
        {
            SceneManager.LoadScene("Scene2");
        }

        // When the player is in Scene4
        if (SceneManager.GetActiveScene().name == "Scene4" && collision.gameObject.tag == "DoorS")
        {
            SceneManager.LoadScene("Scene3a");
        }
        if (SceneManager.GetActiveScene().name == "Scene4" && collision.gameObject.tag == "DoorW")
        {
            SceneManager.LoadScene("Scene5a");
        }
        if (SceneManager.GetActiveScene().name == "Scene4" && collision.gameObject.tag == "DoorN")
        {
            SceneManager.LoadScene("Scene5b");
        }

        // When the player is in Scene5a
        if (SceneManager.GetActiveScene().name == "Scene5a" && collision.gameObject.tag == "DoorE")
        {
            SceneManager.LoadScene("Scene4");
        }
        if (SceneManager.GetActiveScene().name == "Scene5a" && collision.gameObject.tag == "DoorN")
        {
            SceneManager.LoadScene("Scene6");
        }

        // When the player is in Scene5b
        if (SceneManager.GetActiveScene().name == "Scene5b" && collision.gameObject.tag == "DoorS")
        {
            SceneManager.LoadScene("Scene4");
        }

        // When the player is in Scene6
        if (SceneManager.GetActiveScene().name == "Scene6" && collision.gameObject.tag == "DoorS")
        {
            SceneManager.LoadScene("Scene5a");
        }
        if (SceneManager.GetActiveScene().name == "Scene6" && collision.gameObject.tag == "DoorN")
        {
            SceneManager.LoadScene("SceneBoss");
        }
    }
}
