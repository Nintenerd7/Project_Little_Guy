using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIDs : MonoBehaviour
{

    public int buttonID;
    public int buttonType; //0 foodinv, 1 shop

    public Food food;
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeedPet()
    {
        Debug.Log("Fed Pet");
        if(food.foodsOwned[buttonID] >= 1 && (game.petHappiness <= 0.99f || game.petHunger <= 0.99f))
        {
            game.petHappiness += food.moodRecovery[buttonID];
            game.petHunger += food.hungerRecovery[buttonID];
            food.foodsOwned[buttonID]--;
        }
        food.SetFoodTxt();
        game.Save();
    }

    public void BuyItem()
    {
        Debug.Log("Bought Item");
        if(game.coins >= food.cost[buttonID])
        {
            food.foodsOwned[buttonID]++;
            game.coins -= food.cost[buttonID];
        }
        game.SetShopTxt();
        game.Save();
    }
}
