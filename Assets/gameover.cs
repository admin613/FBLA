using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject game;

    public void onClick()
    {
        SceneManager.LoadScene(1);
    }
}
