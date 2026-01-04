using UnityEngine;

public class BossAttackAI : MonoBehaviour
{
    public enum AttackMode { Ranged, Melee }
    public AttackMode currentMode = AttackMode.Ranged;

    [Header("Guns distance (shotgun)")]
    public GameObject gunRightRanged;
    public GameObject gunLeftRanged;
    public GameObject gunUpRanged;
    public GameObject gunDownRanged;

    [Header("Guns mêlée")]
    public GameObject gunRightMelee;
    public GameObject gunLeftMelee;
    public GameObject gunUpMelee;
    public GameObject gunDownMelee;

    GameObject playerCharacter;
    GameObject activeGun;
    GameObject newActiveGun;

    void Start()
    {
        playerCharacter = GameObject.Find("Cat");
        activeGun = null;

        // au démarrage, on peut désactiver tous les guns puis laisser l'Update activer le bon
        DisableAllGuns();
    }

    void Update()
    {
        if (playerCharacter == null) return;

        Vector2 bossPos = transform.position;
        Vector2 playerPos = playerCharacter.transform.position;
        Vector2 dir = playerPos - bossPos;

        // Choix du gun comme dans Ennemy_frontLineAttackAI (comparaison des axes).[file:4]
        if (Mathf.Abs(dir.x) >= Mathf.Abs(dir.y))
        {
            if (dir.x >= 0)
                newActiveGun = (currentMode == AttackMode.Ranged) ? gunRightRanged : gunRightMelee;
            else
                newActiveGun = (currentMode == AttackMode.Ranged) ? gunLeftRanged : gunLeftMelee;
        }
        else
        {
            if (dir.y >= 0)
                newActiveGun = (currentMode == AttackMode.Ranged) ? gunUpRanged : gunUpMelee;
            else
                newActiveGun = (currentMode == AttackMode.Ranged) ? gunDownRanged : gunDownMelee;
        }

        if (newActiveGun != null && newActiveGun != activeGun)
        {
            DisableAllGuns();

            activeGun = newActiveGun;
            activeGun.SetActive(true); // ce gun porte le script de tir (enemy_backLineAttack) ou de cac (enemy_frontLineAttack).[file:7][file:6]
        }
    }

    void DisableAllGuns()
    {
        if (gunRightRanged != null) gunRightRanged.SetActive(false);
        if (gunLeftRanged != null)  gunLeftRanged.SetActive(false);
        if (gunUpRanged != null)    gunUpRanged.SetActive(false);
        if (gunDownRanged != null)  gunDownRanged.SetActive(false);

        if (gunRightMelee != null)  gunRightMelee.SetActive(false);
        if (gunLeftMelee != null)   gunLeftMelee.SetActive(false);
        if (gunUpMelee != null)     gunUpMelee.SetActive(false);
        if (gunDownMelee != null)   gunDownMelee.SetActive(false);
    }

    // Appelé par le script de déplacement
    public void SetRangedMode()
    {
        currentMode = AttackMode.Ranged;
    }

    public void SetMeleeMode()
    {
        currentMode = AttackMode.Melee;
    }
}
