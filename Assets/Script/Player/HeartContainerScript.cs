using UnityEngine;

public class HeartContainerScript : MonoBehaviour
{
    private float contain = 0f;
    public GameObject Heart;

    public float GetContain() { return contain; }

    public void SetContain(float value)
    {
        contain = value;
        UpdateLife();
    }

    private void UpdateLife()
    {
        if (contain == 0)
        {
            Heart.SetActive(false);
        }
        else
        {
            Heart.SetActive(true);
           // if needed, add half heart
        }
    }
}