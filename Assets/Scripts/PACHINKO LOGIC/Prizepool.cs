using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prizepool : MonoBehaviour
{
    public Game game;
    private int coins;
    public GameObject gameManager;

    void Awake()
    {
        GetCoins();
        game = gameManager.GetComponent<Game>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Yellow")//if ball goes into yellow slot 
        {
            Debug.Log("Normal Prize");
            SetCoins(10);
            StartCoroutine(Wait());
        }
        if (collision.tag == "Orange")//if ball goes into the orange slot
        {
            Debug.Log("Rare prize");
            SetCoins(20);
            StartCoroutine(Wait());
        }
        if (collision.tag == "Red")//if ball goes into the Red slot 
        {
            Debug.Log("Super rare prize");
            SetCoins(50);
            StartCoroutine(Wait());
        }
    }

    void GetCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    void SetCoins(int prize)
    {
        GetCoins();
        coins += prize;
        PlayerPrefs.SetInt("Coins", coins);
    }

    IEnumerator Wait()
    {
        Debug.Log("Waiting for scene");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("main");
    }
}
