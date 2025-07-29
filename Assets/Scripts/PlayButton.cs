using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Game game;
    public bool freePachinkoGame;
    public Image buttonImage;
    public Sprite[] buttonSprites;

    void Update()
    {
        if (game.coins >= 10 || freePachinkoGame)
        {
            buttonImage.sprite = buttonSprites[0];
        }
        else
        {
            buttonImage.sprite = buttonSprites[1];
        }
    }
    public void LoadGame()
    {
        if (game.coins >= 10 || freePachinkoGame)
        {
            if(!freePachinkoGame)
            {
                game.coins -= 10;
            }
            if(freePachinkoGame)
            {
                PlayerPrefs.SetString("PachinkoTime", DateTime.Now.ToString());
                PlayerPrefs.Save();
            }
            freePachinkoGame = false;
            game.Save();
            SceneManager.LoadScene("Pachinko_Game");
        }
        else
        {

        }
    }
}
