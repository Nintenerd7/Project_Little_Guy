using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public float petHunger;
    public float petHappiness;
    public TMP_Text petHungerTxt;
    public TMP_Text petHappinessTxt;
    public TMP_Text coinsTxt;
    public TMP_Text shopCoinsTxt;
    public TMP_Text description;
    public TextPrint textPrint;
    [SerializeField] GameObject pet;
    public int petType;
    public Sprite[] happyPets;
    public Sprite[] sadPets;
    public int coins;

    //Shop Stuff
    [SerializeField] GameObject shop;
    [SerializeField] GameObject mainUI;

    //Food Stuff
    [SerializeField] Food food;
    [SerializeField] GameObject foodInv;
    public TMP_Text[] shopHungerPercent;
    public TMP_Text[] shopMoodPercent;
    public TMP_Text[] shopCost;

    //Animation Stuff
    Animator petExpression;
    Animator shopTransitions;
    Animator foodTransitions;
    // Start is called before the first frame update
    void Start()
    {
        #region load pet type
        if(PlayerPrefs.HasKey("Coins"))
        {
            int savedCoins = PlayerPrefs.GetInt("Coins");
            coins = savedCoins;
        }
        else
        {
            coins = 100;
        }
        petExpression = pet.GetComponent<Animator>();
        shopTransitions = shop.GetComponent<Animator>();
        foodTransitions = foodInv.GetComponent<Animator>();
        if (PlayerPrefs.HasKey("PetType"))
        {
            int savedType = PlayerPrefs.GetInt("PetType");
            petType = savedType;
            SetPet();
        }
        else
        {
            petType = 0;
            SetPet();
        }
        #endregion
        #region load pet happiness and hunger
        #region load foods
        if(PlayerPrefs.HasKey("Pancakes"))
        {
            int savedPancakes = PlayerPrefs.GetInt("Pancakes");
            food.foodsOwned[0] = savedPancakes;
        }
        else
        {
            food.foodsOwned[0] = 5;
        }

        if(PlayerPrefs.HasKey("Popcorn"))
        {
            int savedPopcorn = PlayerPrefs.GetInt("Popcorn");
            food.foodsOwned[1] = savedPopcorn;
        }
        else
        {
            food.foodsOwned[1] = 5;
        }

        if(PlayerPrefs.HasKey("Slush"))
        {
            int savedSlush = PlayerPrefs.GetInt("Slush");
            food.foodsOwned[2] = savedSlush;
        }
        else
        {
            food.foodsOwned[2] = 0;
        }

        if(PlayerPrefs.HasKey("Sundae"))
        {
            int savedSundae = PlayerPrefs.GetInt("Sundae");
            food.foodsOwned[3] = savedSundae;
        }

        else
        {
            food.foodsOwned[3] = 0;
        }

        #endregion
        if (PlayerPrefs.HasKey("PetHappiness"))
        {
            float savedHappiness = PlayerPrefs.GetFloat("PetHappiness");
            petHappiness = savedHappiness;
        }
        else
        {
            petHappiness = 1f;
        }
        if (PlayerPrefs.HasKey("PetHunger"))
        {
            float savedHunger = PlayerPrefs.GetFloat("PetHunger");
            petHunger = savedHunger;
        }
        else
        {
            petHunger = 0.5f;
        }
        #endregion
        #region Pet hunger while offline
        if (PlayerPrefs.HasKey("TimeClosed"))
        {
            petHunger = OfflineCalculations(petHunger);
            petHappiness = OfflineCalculations(petHappiness);
        }
        PlayPetExpression();
        Debug.Log("Pet Hunger: " + petHunger);
        Debug.Log("Pet Happiness: " + petHappiness);
        food.SetFoodTxt();
        SetShopTxt();
        UpdateText();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (petHappiness <= 0)
        {
            petHappiness = 0;
        }
        else if (petHappiness >= 1)
        {
            petHappiness = 1;
        }
        if (petHunger <= 0)
        {
            petHunger = 0;
        }
        else if (petHunger >= 1)
        {
            petHunger = 1;
        }

        if (petHappiness <= 0.3f || petHunger <= 0.3f)
        {
            SetSad();
        }
        else
        {
            SetPet();
        }

        UpdateText();
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("TimeClosed", DateTime.Now.ToString());
        PlayerPrefs.SetFloat("PetHunger", petHunger);
        PlayerPrefs.SetFloat("PetHappiness", petHappiness);
        PlayerPrefs.SetInt("PetType", petType);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Pancakes", food.foodsOwned[0]);
        PlayerPrefs.SetInt("Popcorn", food.foodsOwned[1]);
        PlayerPrefs.SetInt("Slush", food.foodsOwned[2]);
        PlayerPrefs.SetInt("Sundae", food.foodsOwned[3]);
        PlayerPrefs.Save();
    }

    float OfflineCalculations(float input)
    {
        Debug.Log("Offline Calculations is running");
        string timeSaved = PlayerPrefs.GetString("TimeClosed");
        DateTime timeClosed = DateTime.Parse(timeSaved);
        Debug.Log("Parsed Time: " + timeClosed);
        TimeSpan timeChange = DateTime.Now - timeClosed;
        return input -= (float)timeChange.TotalHours / 10;
    }

    public void FoodButton()
    {
        //petHunger += 0.25f;
        //petHappiness += 0.1f;
        //Debug.Log("Pet Hunger: " + petHunger);
        //Debug.Log("Pet Happiness: " + petHappiness);
        //petHappinessTxt.text = (Mathf.Round(petHappiness * 100)).ToString() + "%";
        //petHungerTxt.text = (Mathf.Round(petHunger * 100)).ToString() + "%";
        OpenFood();
    }

    void UpdateText()
    {
        petHappinessTxt.text = (Mathf.Round(petHappiness * 100)).ToString() + "%";
        petHungerTxt.text = (Mathf.Round(petHunger * 100)).ToString() + "%";
        coinsTxt.text = coins.ToString();
        shopCoinsTxt.text = coins.ToString();
    }
    void PlayPetExpression()
    {
        if (petHappiness >= 0.8f || petHunger >= 0.8f)
        {
            petExpression.SetBool("isHappy", true);
            petExpression.SetBool("isSad", false);
            textPrint.typingText = textPrint.phrases[0];
            SetPet();
            textPrint.PrintText();
        }
        else if (petHappiness <= 0.3f || petHunger <= 0.3f)
        {
            petExpression.SetBool("isHappy", false);
            petExpression.SetBool("isSad", true);
            textPrint.typingText = textPrint.phrases[2];
            SetSad();
            textPrint.PrintText();
        }
        else
        {
            petExpression.SetBool("isHappy", false);
            petExpression.SetBool("isSad", false);
            textPrint.typingText = textPrint.phrases[1];
            SetPet();
            textPrint.PrintText();
        }

    }
    void SetPet()
    {
        switch (petType)
        {
            case 0:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[0];
                break;
            case 1:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[1];
                break;
            case 2:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[2];
                break;
            case 3:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[3];
                break;
            case 4:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[4];
                break;
            case 5:
                pet.GetComponent<SpriteRenderer>().sprite = happyPets[5];
                break;
        }
    }

    void SetSad()
    {
        switch (petType)
        {
            case 0:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[0];
                break;
            case 1:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[1];
                break;
            case 2:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[2];
                break;
            case 3:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[3];
                break;
            case 4:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[4];
                break;
            case 5:
                pet.GetComponent<SpriteRenderer>().sprite = sadPets[5];
                break;
        }
    }

    public void OpenShop()
    {
        mainUI.SetActive(false);
        description.text = "";
        shopTransitions.SetBool("isShopOpen", true);
        shopTransitions.SetBool("isShopClosed", false);
        SetShopTxt();
        mainUI.SetActive(false);
    }

    public void CloseShop()
    {
        mainUI.SetActive(true);
        shopTransitions.SetBool("isShopOpen", false);
        shopTransitions.SetBool("isShopClosed", true);
    }

    public void OpenFood()
    {
        mainUI.SetActive(false);
        description.text = "";
        foodTransitions.SetBool("isInvOpen", true);
        foodTransitions.SetBool("isInvClosed", false);
        food.SetFoodTxt();
    }

    public void CloseFood()
    {
        food.SetFoodTxt();
        mainUI.SetActive(true);
        foodTransitions.SetBool("isInvOpen", false);
        foodTransitions.SetBool("isInvClosed", true);
    }

    public void SetShopTxt()
    {
        Debug.Log("Setting Shop Shit");
        for(int i = 0; i <= food.foodsOwned.Length - 1; i++)
        {
            Debug.Log("i = " + i);
            shopHungerPercent[i].text = (Mathf.Round(food.hungerRecovery[i] * 100)).ToString() + "%";
            shopMoodPercent[i].text = (Mathf.Round(food.moodRecovery[i] * 100)).ToString() + "%";
            shopCost[i].text = food.cost[i].ToString();
        }
    }
}
