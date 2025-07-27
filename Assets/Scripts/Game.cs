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
    [SerializeField] GameObject pet;

    //Animation Stuff
    Animator petExpression;
    // Start is called before the first frame update
    void Start()
    {
        petExpression = pet.GetComponent<Animator>();

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
        UpdateText();
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetString("TimeClosed", DateTime.Now.ToString());
        PlayerPrefs.SetFloat("PetHunger", petHunger);
        PlayerPrefs.SetFloat("PetHappiness", petHappiness);
        PlayerPrefs.Save();
    }

    float OfflineCalculations(float input)
    {
        Debug.Log("Offline Calculations is running");
        string timeSaved = PlayerPrefs.GetString("TimeClosed");
        DateTime timeClosed = DateTime.Parse(timeSaved);
        Debug.Log("Parsed Time: " + timeClosed);
        TimeSpan timeChange = DateTime.Now - timeClosed;
        return input -= (float)timeChange.TotalHours/10;
    }

    public void FoodButton()
    {
        petHunger += 0.25f;
        petHappiness += 0.1f;
        //if (petHunger <= 0)
        //{
        //    petHunger = 0;
        //}
        //else if (petHunger >= 1)
        //{
        //    petHunger = 1;
        //}
        //if (petHappiness <= 0)
        //{
        //    petHappiness = 0;
        //}
        //else if (petHappiness >= 1)
        //{
        //    petHappiness = 1;
        //}
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
        if(petHappiness >= 0.8f || petHunger >= 0.8f)
        {
            petExpression.SetBool("isHappy", true);
            petExpression.SetBool("isSad", false);
        }
        else if(petHappiness <= 0.3f || petHunger <= 0.3f)
        {
            petExpression.SetBool("isHappy", false);
            petExpression.SetBool("isSad", true);
        }
        else
        {
            petExpression.SetBool("isHappy", false);
            petExpression.SetBool("isSad", false);
        }

    }
}
