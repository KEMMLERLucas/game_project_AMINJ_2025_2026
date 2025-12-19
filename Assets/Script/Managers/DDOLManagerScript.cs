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
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObjectsDontDestroyOnLoad = new List<GameObject>();
    }

    void Update()
    {
        
    }

    public void DontDestroy(GameObject gameObject)
    {
        gameObjectsDontDestroyOnLoad.Add(gameObject);
    }

    public void DestroyEverything()
    {
        foreach (GameObject gameObject in gameObjectsDontDestroyOnLoad)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
