using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Get Mouse Up");
            if(PlayerPrefs.HasKey("PetType"))
            {
                SceneManager.LoadScene("main");
            }
            else
            {
                SceneManager.LoadScene("PetSelection");
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                if(PlayerPrefs.HasKey("PetType"))
                {
                    SceneManager.LoadScene("main");
                }
                else
                {
                    SceneManager.LoadScene("PetSelection");
                }
                
            }
            
        }
    }
}
