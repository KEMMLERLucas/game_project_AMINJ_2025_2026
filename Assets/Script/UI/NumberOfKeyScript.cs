using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumberOfKeyScript : MonoBehaviour
{
    public List<Sprite> numberOfKeys;
    int actualNumberOfKeys = 0;
    public static NumberOfKeyScript instance;

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
    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.K))
        {
            CollectKey();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UseKey();
        } */
    }

    public void CollectKey()
    {
        actualNumberOfKeys++;
        GetComponent<SpriteRenderer>().sprite = numberOfKeys[actualNumberOfKeys];
    }

    public void UseKey()
    {
        actualNumberOfKeys--;
        GetComponent<SpriteRenderer>().sprite = numberOfKeys[actualNumberOfKeys];
    }

    public int GetActualNumberOfKeys()
    {
        return actualNumberOfKeys;
    }
}