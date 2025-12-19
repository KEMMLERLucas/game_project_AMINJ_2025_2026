using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DDOLManagerScript : MonoBehaviour
{

    public static DDOLManagerScript instance;
    List<GameObject> gameObjectsDontDestroyOnLoad;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        gameObjectsDontDestroyOnLoad = new List<GameObject>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void DontDestroy(GameObject gameObjectToDontDestroy)
    {
        DontDestroyOnLoad(gameObjectToDontDestroy);
        gameObjectsDontDestroyOnLoad.Add(gameObjectToDontDestroy);
    }

    public void DestroyEverything()
    {
        foreach (GameObject gameObjectToDestroy in gameObjectsDontDestroyOnLoad)
        {
            Destroy(gameObjectToDestroy);
        }

        Destroy(gameObject);
    }
}
