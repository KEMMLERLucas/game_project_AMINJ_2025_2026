using UnityEngine;
using UnityEngine.SceneManagement;
public class StartOnClickScript : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
    }

}
