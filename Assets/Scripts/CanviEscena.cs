using UnityEngine;
using UnityEngine.SceneManagement;

public class CanviEscena : MonoBehaviour
{
    public string sceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}