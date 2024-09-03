using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader 
{
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
    }
    public static void loadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if (sceneIndex >= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
