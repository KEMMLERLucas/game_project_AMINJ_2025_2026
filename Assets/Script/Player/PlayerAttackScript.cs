using System;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Melee;
    bool isAttacking = false;
    public float atkDuration = 0.3f;
    public float atkTimer = 0f;
    public float aimRadius = 1f;
    public LayerMask enemyLayer;

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
            if (Input.GetKeyUp(KeyCode.Z))
            {
                //Debug.Log("Touche Z relâchée - attaque vers le haut");
                OnAttack(Vector3.up, attackUpOffset);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                //Debug.Log("Touche S relâchée - attaque vers le bas");
                OnAttack(Vector3.down, attackDownOffset);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                //Debug.Log("Touche Q relâchée - attaque vers la gauche");
                OnAttack(Vector3.left, attackLeftOffset);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                //Debug.Log("Touche D relâchée - attaque vers la droite");
                OnAttack(Vector3.right, attackRightOffset);
            }
        }
    }
    void OnAttack(Vector3 direction, Vector3 offset)
    {
        // Finding Enemies
        isAttacking = true;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + offset, aimRadius, enemyLayer);
        Vector3 aimPosition = transform.position + offset;
        Debug.Log("Nombre d'ennemis détectés dans la zone d'attaque : " + hits.Length);
        if (hits.Length > 0) {
            float closestDistance = Mathf.Infinity;
            Collider2D closestEnemy = null;
            foreach (var hit in hits){
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist < closestDistance) { 
                closestDistance = dist;
                    closestEnemy = hit;
                }
            }
            if (closestEnemy != null) { 
                aimPosition = closestEnemy.transform.position;
                //Debug.Log("Ennemi le plus proche à la position : " + aimPosition);
            }
        }

        Melee.SetActive(true);

        Melee.transform.position = aimPosition;
        Melee.transform.localPosition = offset;

        //Manage the rotation of the attack
        float angle = 0f;
        if (direction == Vector3.up) angle = 0f;
        else if (direction == Vector3.down) angle = 0f;
        else if (direction == Vector3.left) angle = 90f;
        else if (direction == Vector3.right) angle = 90f;

        Melee.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            atkTimer += Time.deltaTime;
            if(atkTimer > atkDuration)
            {
                //Debug.Log("Fin de l'attaque");
                atkTimer = 0;
                isAttacking= false;
                Melee.SetActive(false);
                Melee.transform.localPosition = Vector3.zero;
            }
        }
    }

}
