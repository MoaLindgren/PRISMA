using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenyManager : MonoBehaviour {

    public void StartGame1()
    {
        SceneManager.LoadScene("Game3");
    }

    public void StartGame2()
    {
        SceneManager.LoadScene("Game4");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
