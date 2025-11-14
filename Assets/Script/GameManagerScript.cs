using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] public int maxLife = 8;
    [SerializeField] public float healthPoint = 4;
    public static GameManagerScript instance;
    [SerializeField] public GameObject[] HeartContainers;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateHeartContainers();
        UpdateLife();
    }

    public void UpdateHeartContainers()
    {
        for (int i = 0; i < maxLife; i++)
        {
            HeartContainers[i].SetActive(true);
        }
    }

    public void UpdateLife()
    {
        int fullHearts = Mathf.FloorToInt(healthPoint);
        for (int i = 0; i < fullHearts; i++)
        {
            HeartContainers[i].GetComponent<HeartContainerScript>().SetContainer(1f);
        }

        if (fullHearts < maxLife)
        {
            float partial = healthPoint - fullHearts;
            HeartContainers[fullHearts].GetComponent<HeartContainerScript>().SetContainer(partial);

            for (int i = fullHearts + 1; i < maxLife; i++)
            {
                HeartContainers[i].GetComponent<HeartContainerScript>().SetContainer(0f);
            }
        }
        else
        {
            for (int i = fullHearts; i < maxLife; i++)
            {
                HeartContainers[i].GetComponent<HeartContainerScript>().SetContainer(0f);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
        Debug.Log($"Joueur a pris {damage} d?g?ts. Sant?: {healthPoint}");
        UpdateLife();
        if (healthPoint <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Le joueur est mort!");
        Destroy(gameObject);
    }
}