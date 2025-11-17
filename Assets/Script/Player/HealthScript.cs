using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthScript : MonoBehaviour
{
    public List<Sprite> currentHealth;
    int damageTaken = 1;

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
            Heal();
        }
    }

    private void TakingDamage()
    {
        damageTaken++;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
    }

    private void Heal()
    {
        damageTaken--;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
    }
}
