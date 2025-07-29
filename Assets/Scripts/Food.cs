using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{
    public float[] hungerRecovery;
    public float[] moodRecovery;
    public int[] cost;

    public int[] foodsOwned;

    public Image[] buttons;
    public Image[] foods;
    public Sprite[] buttonSprites;
    public Sprite[] panSprites;
    public Sprite[] popSprites;
    public Sprite[] sluSprites;
    public Sprite[] sunSprites;

    public TMP_Text[] hungerPercent;
    public TMP_Text[] moodPercent;
    public TMP_Text[] ownedNum;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFoodTxt()
    {
        for (int i = 0; i <= foodsOwned.Length - 1; i++)
        {
            if(foodsOwned[i] <= 0) //Make food gray if not in stock
            {
                buttons[i].sprite = buttonSprites[1];
                switch (i)
                {
                    case 0:
                        foods[i].sprite = panSprites[1];
                    break;
                    case 1:
                        foods[i].sprite = popSprites[1];
                    break;
                    case 2:
                        foods[i].sprite = sluSprites[1];
                    break;
                    case 3:
                        foods[i].sprite = sunSprites[1];
                    break;
                }
            }
            else //Make foods coloured if in stock
            {
                buttons[i].sprite = buttonSprites[0];
                switch (i)
                {
                    case 0:
                        foods[i].sprite = panSprites[0];
                    break;
                    case 1:
                        foods[i].sprite = popSprites[0];
                    break;
                    case 2:
                        foods[i].sprite = sluSprites[0];
                    break;
                    case 3:
                        foods[i].sprite = sunSprites[0];
                    break;
                }
            }

            ownedNum[i].text = foodsOwned[i].ToString(); //Display number of foods owned
            hungerPercent[i].text = (Mathf.Round(hungerRecovery[i] * 100)).ToString() + "%";
            moodPercent[i].text = (Mathf.Round(moodRecovery[i] * 100)).ToString() + "%";
        }
    }
}
