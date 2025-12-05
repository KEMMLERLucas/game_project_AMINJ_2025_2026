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

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void TakingDamage()
    {
        damageTaken++;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];

        if (currentHealth[8])
        {
            Debug.Log("YOU LOSE");
        }
    }

    public void Healing()
    {
        damageTaken--;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
    }
}
