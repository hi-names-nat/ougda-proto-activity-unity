//Don't worry about this script.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        var sceneHandle = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneHandle);
    }
}
