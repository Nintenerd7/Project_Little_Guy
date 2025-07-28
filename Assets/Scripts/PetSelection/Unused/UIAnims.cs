using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnims : MonoBehaviour
{
    public SwipeControls swipeControls;
    public int[] petIDs;
    public Animator[] movePets;
    public Sprite[] icons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnAnimationEnd()
    {
        Debug.Log("Entered Animation End");
        GetIDs();
        SetIDs();
        swipeControls.MoveLeft = false;
        swipeControls.MoveRight = false;
        for (int i = 0; i <= movePets.Length - 1; i++)
        {
            Debug.Log("Reset Anim Bools");
            movePets[i].SetBool("MoveLeft", false);
            movePets[i].SetBool("MoveRight", false);
            swipeControls.petIcons[i].sprite = icons[petIDs[i]];
        }
    }

    public void GetIDs()
    {
        petIDs = swipeControls.petIDs;
    }
    public void SetIDs()
    {
        for (int i = 0; i == petIDs.Length; i++)
        {
            if (swipeControls.MoveLeft)
            {
                if (petIDs[i] - 1 <= -1)
                {
                    petIDs[i] = 5;
                }
                petIDs[i] = petIDs[i] - 1;
            }
            else if (swipeControls.MoveRight)
            {
                if (petIDs[i] + 1 >= 6)
                {
                    petIDs[i] = 0;
                }
                petIDs[i] = petIDs[i] + 1;
            }
        }
    }
}
