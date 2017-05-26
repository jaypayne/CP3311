using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void Start_Game(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void Quit_Game()
    {
        Application.Quit();
    }

}
