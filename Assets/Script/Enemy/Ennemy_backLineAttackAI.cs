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
    //GameObject newActiveun;
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
                activeGun = gunRight;
                
            }

            else if (gunOrientation.x < 0)
            {
               activeGun = gunLeft;
            }
        }
        else if (Mathf.Abs(gunOrientation.x) < Mathf.Abs(gunOrientation.y))
        {
            if (gunOrientation.y >= 0)
            {
               activeGun = gunUp;
            }

            else if (gunOrientation.y < 0)
            {
               activeGun = gunDown;
            }
        }
        activeGun.SetActive(true);
    }
}
