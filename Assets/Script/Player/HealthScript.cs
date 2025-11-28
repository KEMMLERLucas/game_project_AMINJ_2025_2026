using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthScript : MonoBehaviour
{
    public List<Sprite> currentHealth;
    int damageTaken = 1;
    public static HealthScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // I put random conditions to test but we have to change them
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakingDamage();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Healing();
        }
    }

    public void TakingDamage()
    {
        damageTaken++;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
    }

    public void Healing()
    {
        damageTaken--;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
    }
}
