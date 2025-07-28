using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControls : MonoBehaviour
{

    public bool MoveRight;
    public bool MoveLeft;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    public Animator[] movePets;
    public Image[] petIcons;
    public int[] petIDs = new int[] { 2, 1, 0, 5, 4 };

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;

            if (endTouchPos.x < startTouchPos.x)
            {
                Next();
            }
            if (endTouchPos.x > startTouchPos.x)
            {
                Prev();
            }
        }
    }

    public void Next()
    {
        MoveLeft = true;
        MoveRight = false;
        for (int i = 0; i <= movePets.Length-1; i++)
        {
            movePets[i].SetBool("MoveLeft", true);
            movePets[i].SetBool("MoveRight", false);
        }
    }

    public void Prev()
    {
        MoveLeft = false;
        MoveRight = true;
        for (int i = 0; i <= movePets.Length-1; i++)
        {
            movePets[i].SetBool("MoveLeft", false);
            movePets[i].SetBool("MoveRight", true);
        }
    }

    

}
