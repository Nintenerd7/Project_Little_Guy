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
    // Start is called before the first frame update
    void Start()
    {
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
        #region Pet hunger while offline
        if (PlayerPrefs.HasKey("TimeClosed"))
        {
            petHunger = OfflineCalculations(petHunger);
            petHappiness = OfflineCalculations(petHappiness);
        }

        Debug.Log("Pet Hunger: " + petHunger);
        Debug.Log("Pet Happiness: " + petHappiness);
        petHappinessTxt.text = "Pet Mood: " + (Mathf.Round(petHappiness * 100)).ToString() + "%";
        petHungerTxt.text = "Pet Hunger: " + (Mathf.Round(petHunger * 100)).ToString() + "%";
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
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
        return input -= (float)timeChange.TotalHours;
    }

    public void FoodButton()
    {
        petHunger += 0.25f;
        petHappiness += 0.1f;
        if (petHunger <= 0)
        {
            petHunger = 0;
        }
        else if (petHunger >= 1)
        {
            petHunger = 1;
        }
        if (petHappiness <= 0)
        {
            petHappiness = 0;
        }
        else if (petHappiness >= 1)
        {
            petHappiness = 1;
        }
        Debug.Log("Pet Hunger: " + petHunger);
        Debug.Log("Pet Happiness: " + petHappiness);
        petHappinessTxt.text = "Pet Mood: " + (Mathf.Round(petHappiness * 100)).ToString() + "%";
        petHungerTxt.text = "Pet Hunger: " + (Mathf.Round(petHunger * 100)).ToString() + "%";
    }
}
