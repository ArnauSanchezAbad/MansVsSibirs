using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SortirDelJoc : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
