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
        Direction("Scene1", "DoorN", "Scene2", collision);

        // When the player is in Scene2
        Direction("Scene2", "DoorS", "Scene1", collision);
        Direction("Scene2", "DoorW", "Scene3b", collision);
        Direction("Scene2", "DoorE", "Scene3a", collision);

        // When the player is in Scene3a
        Direction("Scene3a", "DoorE", "Scene2", collision);
        Direction("Scene3a", "DoorN", "Scene4", collision);

        // When the player is in Scene3b
        Direction("Scene3b", "DoorE", "Scene2", collision);

        // When the player is in Scene4
        Direction("Scene4", "DoorS", "Scene3a", collision);
        Direction("Scene4", "DoorW", "Scene5a", collision);
        Direction("Scene4", "DoorN", "Scene5b", collision);

        // When the player is in Scene5a
        Direction("Scene5a", "DoorE", "Scene4", collision);
        Direction("Scene5a", "DoorN", "Scene6", collision);

        // When the player is in Scene5b
        Direction("Scene5b", "DoorS", "Scene4", collision);

        // When the player is in Scene6
        Direction("Scene6", "DoorS", "Scene5a", collision);
        Direction("Scene6", "DoorN", "SceneBoss", collision);
       }

    public void Direction(string playerLocation, string doorCollision, string playerDestination, Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == playerLocation && collision.gameObject.tag == doorCollision)
        {
            SceneManager.sceneLoaded += playerMovement.InitializeCorners;
            SceneManager.LoadScene(playerDestination);
        }
    }
}
