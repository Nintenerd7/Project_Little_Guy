using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetSelection : MonoBehaviour
{
    public int ButtonID;

    // Start is called before the first frame update
    public void SelectPet()
    {
        PlayerPrefs.SetInt("PetType", ButtonID);
        SceneManager.LoadScene("main");
    }
}
