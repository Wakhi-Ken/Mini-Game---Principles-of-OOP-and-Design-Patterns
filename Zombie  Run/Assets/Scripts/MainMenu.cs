using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("zombie chase");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}