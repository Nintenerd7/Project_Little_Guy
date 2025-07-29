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
    public TextPrint textPrint;
    [SerializeField] GameObject pet;
    public int petType;
    public Sprite[] happyPets;
    public Sprite[] sadPets;
<<<<<<< Updated upstream
=======
    public int coins;
    public PlayButton playButton;

    //Shop Stuff
    [SerializeField] GameObject shop;
    [SerializeField] GameObject mainUI;

    //Food Stuff
    [SerializeField] Food food;
    [SerializeField] GameObject foodInv;
    public TMP_Text[] shopHungerPercent;
    public TMP_Text[] shopMoodPercent;
    public TMP_Text[] shopCost;
>>>>>>> Stashed changes

    //Animation Stuff
    Animator petExpression;
    // Start is called before the first frame update
    void Start()
    {
        petExpression = pet.GetComponent<Animator>();
        if (PlayerPrefs.HasKey("PetType"))
        {
<<<<<<< Updated upstream
            int savedType = PlayerPrefs.GetInt("PetType");
            petType = savedType;
            SetPet();
=======
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
            if (PlayerPrefs.HasKey("DailyPachinko"))
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
>>>>>>> Stashed changes
        }
        else
        {
            petType = 0;
            SetPet();
        }
        #region load pet happiness and hunger
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
<<<<<<< Updated upstream
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
=======

        PachinkoCalcs(playButton.freePachinkoGame);
>>>>>>> Stashed changes
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("TimeClosed", DateTime.Now.ToString());
        PlayerPrefs.SetFloat("PetHunger", petHunger);
        PlayerPrefs.SetFloat("PetHappiness", petHappiness);
        PlayerPrefs.SetInt("PetType", petType);
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

    bool PachinkoCalcs(bool dailyPachinko)
    {
        string timeSaved = PlayerPrefs.GetString("PachinkoTime");
        DateTime pachinkoTime = DateTime.Parse(timeSaved);
        Debug.Log("Parsed Time: " + pachinkoTime);
        TimeSpan timeChange = DateTime.Now - pachinkoTime;
        if((float)timeChange.TotalHours >= 24)
        {
            return dailyPachinko = true;
        }
        else
        {
            return dailyPachinko = false;
        }
    }

    public void FoodButton()
    {
        petHunger += 0.25f;
        petHappiness += 0.1f;
        Debug.Log("Pet Hunger: " + petHunger);
        Debug.Log("Pet Happiness: " + petHappiness);
        petHappinessTxt.text = "Pet Mood: " + (Mathf.Round(petHappiness * 100)).ToString() + "%";
        petHungerTxt.text = "Pet Hunger: " + (Mathf.Round(petHunger * 100)).ToString() + "%";
    }

    void UpdateText()
    {
        petHappinessTxt.text = "Pet Mood: " + (Mathf.Round(petHappiness * 100)).ToString() + "%";
        petHungerTxt.text = "Pet Hunger: " + (Mathf.Round(petHunger * 100)).ToString() + "%";
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
}
