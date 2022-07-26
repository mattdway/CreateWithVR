using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene using name, or reload the active scene
/// </summary>
public class LoadScene : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "XR Rig")
        {
            ReloadCurrentScene();
        }
    }

    public void LoadSceneUsingName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
