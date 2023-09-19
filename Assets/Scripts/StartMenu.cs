using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void newGame()
    {
        LevelManager.level = 1;
        LevelManager.LevelUp = false;
        PlayerController.loadd = false;
        UpdatePlayer.loadUpdatePlayer = false;
        LevelManager.load = false;
        Enemy.load = false;
        SceneManager.LoadScene(1);
        LevelManager.nameLevel = "Map1";
    }
}
