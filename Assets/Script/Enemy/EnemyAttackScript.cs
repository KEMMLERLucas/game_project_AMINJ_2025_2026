using System.Collections;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
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
