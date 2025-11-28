using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlashScript : MonoBehaviour
{
    public float attackTime;

    void Start()
    {
       StartCoroutine("DeleteAttackAfterDelay");
    }

    void Update()
    {
        
    }


    System.Collections.IEnumerator DeleteAttackAfterDelay()
    {
        yield return new WaitForSeconds(attackTime);
        Destroy(gameObject);
    }
}