using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Home()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) { return; }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Add()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) { return; }
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
