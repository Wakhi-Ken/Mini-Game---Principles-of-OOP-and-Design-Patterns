using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        // Load the scene named "zombie chase"
        SceneManager.LoadScene("zombie chase");
    }

    public void Quit()
    {
        // Quit the application
        Application.Quit();
        Debug.Log("Quit Game");
    }
}