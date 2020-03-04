using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{

    /**
     * @params
     * @return
     */
    void Start()
    {        
        
    }

    /**
     * @params
     * @return
     */
    void Update()
    {

    }

    /**
     * @params
     * @return
     */
    public void levelloader(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        int indexCounter = SceneManager.GetActiveScene().buildIndex;

        //works if it is not the last scene, needs playing with
        if (indexCounter == 8) 
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }
}
