using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuEvents : MonoBehaviour
{
    public GameObject canvas;
    public void playClick()
    {
        SceneManager.LoadScene(1);
    }
    public void quitClick()
    {
        Application.Quit();
    }
    public void instructionsClick()
    {
        canvas.SetActive(true);
    }
    public void instructionsExitClick()
    {
        canvas.SetActive(false);
    }

}
