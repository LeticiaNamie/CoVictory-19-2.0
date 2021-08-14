using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int scene;
    
    void Start()
    {
    	Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.anyKey && scene == 0)
        {
        	SceneManager.LoadScene("Instructions2");
        }
        else if(Input.anyKey && scene == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if(Input.anyKey && scene == 2)
        {
            SceneManager.LoadScene("Game");
        }
        else if(Input.anyKey && scene == 3)
        {
            SceneManager.LoadScene("Game 2");
        }
        else if(Input.anyKey && scene == 4)
        {
            SceneManager.LoadScene("Game 3");
        }
    }
}
