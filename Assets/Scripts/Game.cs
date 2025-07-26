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
            string timeSaved = PlayerPrefs.GetString("TimeClosed");
            DateTime timeClosed = DateTime.Parse(timeSaved);
            Debug.Log("Parsed Time: " + timeClosed);
            TimeSpan timeChange = DateTime.Now - timeClosed;
            petHunger -= (float)timeChange.TotalHours;

            OfflineCalculations(petHunger);
            OfflineCalculations(petHappiness);
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

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("TimeClosed", DateTime.Now.ToString());
        PlayerPrefs.SetFloat("PetHunger", petHunger);
        PlayerPrefs.SetFloat("PetHappiness", petHappiness);
        PlayerPrefs.Save();
    }

    void OfflineCalculations(float input)
    {
            string timeSaved = PlayerPrefs.GetString("TimeClosed");
            DateTime timeClosed = DateTime.Parse(timeSaved);
            Debug.Log("Parsed Time: " + timeClosed);
            TimeSpan timeChange = DateTime.Now - timeClosed;
            input -= (float)timeChange.TotalHours;
    }
}
