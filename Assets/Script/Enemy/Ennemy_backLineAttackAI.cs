using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Ennemy_backLineAttackAI : MonoBehaviour
{
    public GameObject gunRight;
    public GameObject gunLeft;
    public GameObject gunUp;
    public GameObject gunDown;
    GameObject playerCharacter;
    GameObject activeGun;
    GameObject newActiveGun;
    Vector2 ennemyPosition;
    Vector2 gunOrientation;
    void Start()
    {
        playerCharacter = GameObject.Find("Cat");
        ennemyPosition = transform.position;
        activeGun = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerCharacterPosition = playerCharacter.transform.position;
        gunOrientation = playerCharacterPosition - ennemyPosition;

        if (Mathf.Abs(gunOrientation.x) >= Mathf.Abs(gunOrientation.y))
        {
            if (gunOrientation.x >= 0)
            {
                newActiveGun = gunRight;
            }

            else if (gunOrientation.x < 0)
            {
               newActiveGun = gunLeft;
            }
        }
        else if (Mathf.Abs(gunOrientation.x) < Mathf.Abs(gunOrientation.y))
        {
            if (gunOrientation.y >= 0)
            {
               newActiveGun = gunUp;
            }

            else if (gunOrientation.y < 0)
            {
               newActiveGun = gunDown;
            }
        }

        if (newActiveGun != null && newActiveGun != activeGun)
        {
            if (activeGun != null)
            {
                activeGun.SetActive(false);
            }
            activeGun = newActiveGun;
            activeGun.SetActive(true);
        }
            
    }
}
