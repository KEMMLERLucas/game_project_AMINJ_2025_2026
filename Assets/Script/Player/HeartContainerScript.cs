using UnityEngine;

public class HeartContainerScript : MonoBehaviour
{
    private float container = 0f;
    public GameObject Heart;

    public float GetContainer() { return container; }

    public void SetContainer(float value)
    {
        container = value;
        UpdateLife();
    }

    private void UpdateLife()
    {
        if (container == 0)
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