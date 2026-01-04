using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float attackTime = 0.3f; 

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim != null)
            anim.Play("Slash", 0, 0f);


        Destroy(gameObject, attackTime);
    }
}
