using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
        DDOLManagerScript.instance.DontDestroy(gameObject);
    }

    public void TakingDamage()
    {
        damageTaken++;
        GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];

        if (GetComponent<SpriteRenderer>().sprite == currentHealth[9])
        {
            SceneManager.LoadScene("MainMenuScene");
            DDOLManagerScript.instance.DestroyEverything();
        }
    }
    public void Healing()
    {
        if (currentHealth[damageTaken] != currentHealth[0])
        {
            damageTaken--;
            GetComponent<SpriteRenderer>().sprite = currentHealth[damageTaken];
        }
    }

    public bool CanHeal()
    {
        return currentHealth[damageTaken] != currentHealth[0];
    }
}
