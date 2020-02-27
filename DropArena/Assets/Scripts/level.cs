using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
