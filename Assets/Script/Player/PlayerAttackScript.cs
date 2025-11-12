using System;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Melee;
    bool isAttacking = false;
    float atkDuration = 0.3f;
    float atkTimer = 0f;

    public Vector3 attackUpOffset = new Vector3(0, 0.2f, 0);
    public Vector3 attackDownOffset = new Vector3(0, -0.2f, 0);
    public Vector3 attackLeftOffset = new Vector3(-0.2f, 0, 0);
    public Vector3 attackRightOffset = new Vector3(0.2f, 0, 0);
    void Start()
    {
        
    }

    void Update()
    {
        CheckMeleeTimer();

        if (!isAttacking)
        {
            if (Input.GetKeyUp(KeyCode.Z)) { OnAttack(Vector3.up, attackUpOffset); }
            else if (Input.GetKeyUp(KeyCode.S)) { OnAttack(Vector3.down, attackDownOffset); }
            else if (Input.GetKeyUp(KeyCode.Q)) { OnAttack(Vector3.left, attackLeftOffset); }
            else if (Input.GetKeyUp(KeyCode.D)) { OnAttack(Vector3.right, attackRightOffset); }
        }
    }
    void OnAttack(Vector3 direction, Vector3 offset)
    {
        isAttacking = true;
        Melee.SetActive(true);
        Melee.transform.localPosition = offset;
        float angle = 0f;
        if (direction == Vector3.up) angle = 90f;
        else if (direction == Vector3.down) angle = -90f;
        else if (direction == Vector3.left) angle = 180f;
        else if (direction == Vector3.right) angle = 0f;
        if (direction == Vector3.up) Debug.Log("Haut");
        else if (direction == Vector3.down) Debug.Log("bas");
        else if (direction == Vector3.left) Debug.Log("gauche");
        else if (direction == Vector3.right) Debug.Log("droite");

        Melee.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer > atkDuration)
            {
                atkTimer = 0;
                isAttacking= false;
                Melee.SetActive(false);
                Melee.transform.localPosition = Vector3.zero;
            }
        }
    }

}
