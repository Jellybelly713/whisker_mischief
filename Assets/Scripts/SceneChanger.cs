using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void enter()
    {
        Debug.Log("Enter");
        SceneManager.LoadScene("Enter");
    }
    public void game()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void home()
    {
        SceneManager.LoadScene("Home");
    }

    public void instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void instructionsPoints()
    {
        SceneManager.LoadScene("InstructionsPoints");
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        { 
           
        }
    }
}
