using System.Collections;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeToDeath = 1f;

    void Start()
    {
        StartCoroutine(Despawn());    
    }

   IEnumerator Despawn()
    {
        yield return new WaitForSeconds(timeToDeath);
        Destroy(gameObject);
    }
}
