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
        // When the player is in SceneStart
        ChangeScene("SceneStart", "DoorN", "Scene2", collision);

        // When the player is in Scene1
        ChangeScene("Scene1", "DoorN", "Scene2", collision);

        // When the player is in Scene2
        ChangeScene("Scene2", "DoorS", "Scene1", collision);
        ChangeScene("Scene2", "DoorW", "Scene3b", collision);
        ChangeScene("Scene2", "DoorE", "Scene3a", collision);

        // When the player is in Scene3a
        ChangeScene("Scene3a", "DoorW", "Scene2", collision);
        ChangeScene("Scene3a", "DoorN", "Scene4", collision);

        // When the player is in Scene3b
        ChangeScene("Scene3b", "DoorE", "Scene2", collision);

        // When the player is in Scene4
        ChangeScene("Scene4", "DoorS", "Scene3a", collision);
        ChangeScene("Scene4", "DoorW", "Scene5a", collision);
        ChangeScene("Scene4", "DoorN", "Scene5b", collision);

        // When the player is in Scene5a
        ChangeScene("Scene5a", "DoorE", "Scene4", collision);
        ChangeScene("Scene5a", "DoorN", "Scene6", collision);

        // When the player is in Scene5b
        ChangeScene("Scene5b", "DoorS", "Scene4", collision);

        // When the player is in Scene6
        ChangeScene("Scene6", "DoorS", "Scene5a", collision);
        ChangeScene("Scene6", "DoorN", "SceneBoss", collision);
       }

    public void ChangeScene(string playerLocation, string doorCollision, string playerDestination, Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == playerLocation && collision.gameObject.tag == doorCollision)
        {
            SceneManager.sceneLoaded += playerMovement.InitializeCorners;
            SceneManager.LoadScene(playerDestination);

            if (doorCollision == "DoorN")
            {
                transform.position = new Vector3(0f, -3.3f, 0f);
            }

            if (doorCollision == "DoorS")
            {
                transform.position = new Vector3(0f, 3.3f, 0f);
            }

            if (doorCollision == "DoorW")
            {
                transform.position = new Vector3(6.5f, 0f, 0f);
            }

            if (doorCollision == "DoorE")
            {
                transform.position = new Vector3(-6.5f, 0f, 0f);
            }
        }
    }
}
