using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{
    public List<Sprite> successiveSprites;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {

    }
}