using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Game game;

    public void LoadGame()
    {
        game.Save();
        SceneManager.LoadScene("Pachinko_Game");
    }
}
