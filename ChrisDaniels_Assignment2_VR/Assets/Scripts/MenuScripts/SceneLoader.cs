using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /**
     * Loads desired scene, passed scene index from method/button. Static method allow this to be accessed
     * in multiple scripts.
     * 
     */
    public static void LoadMyScene(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);

    }


    /**
     * Ends application and returns to oculus home screen
     */
    public void EndApplication()
    {
        Application.Quit();


    }
}
