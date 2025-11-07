using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float collisionOffset;
    Transform cornerNETransform;
    Transform cornerNWTransform;
    Transform cornerSETransform;
    Transform cornerSWTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cornerNETransform = GameObject.Find("CornerNE").transform;
        cornerNWTransform = GameObject.Find("CornerNW").transform;
        cornerSETransform = GameObject.Find("CornerSE").transform;
        cornerSWTransform = GameObject.Find("CornerSW").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < cornerNETransform.position.x - collisionOffset && transform.position.x < cornerSETransform.position.x - collisionOffset)
        {
            transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > cornerNWTransform.position.x + collisionOffset && transform.position.x > cornerSWTransform.position.x + collisionOffset)
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < cornerNETransform.position.y - collisionOffset && transform.position.y < cornerNWTransform.position.y - collisionOffset)
        {
            transform.position += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > cornerSETransform.position.y + collisionOffset && transform.position.y > cornerSWTransform.position.y + collisionOffset)
        {
            transform.position += Vector3.down * speed;
        }
    }

    public void InitializeCorners(Scene scene, LoadSceneMode loadSceneMode)
    {
        cornerNETransform = GameObject.Find("CornerNE").transform;
        cornerNWTransform = GameObject.Find("CornerNW").transform;
        cornerSETransform = GameObject.Find("CornerSE").transform;
        cornerSWTransform = GameObject.Find("CornerSW").transform;
    }
}
