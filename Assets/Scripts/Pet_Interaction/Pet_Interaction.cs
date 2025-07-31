using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Interaction : MonoBehaviour
{
    public GameObject[] Hidden_Elements = new GameObject[4];//holds list of buttons needing to be hidden
    public GameObject hand;//Headpat gameobject
    public Game Game_Manager;//getting the pet happiness value.

    public void HeadpatButton()
    {
        StartCoroutine(Headpat());//player gives headpats to the pet.
        Debug.Log("*Pat Pat*");//signifies your caring for your pet in console
    }

    public IEnumerator Headpat()
    {
        HideButtons();//hides buttons
        hand.SetActive(true);//headpats are there 
        yield return new WaitForSeconds(1);//waits for 1 second
        Game_Manager.petHappiness += 0.5f;//Adds happiness (WHICH WORRKS YIPPEE!!)
        hand.SetActive(false);//headpats are not there.
        ShowButtons();//shows buttons
    }

    #region VISIBILITY METHODS
    //sets buttons visibility to false
    public void HideButtons()
    {
      Hidden_Elements[0].SetActive(false);
      Hidden_Elements[1].SetActive(false);
      Hidden_Elements[2].SetActive(false);
      Hidden_Elements[3].SetActive(false);
    }
    //sets buttons visibility to true
    public void ShowButtons()
    {
        Hidden_Elements[0].SetActive(true);
        Hidden_Elements[1].SetActive(true);
        Hidden_Elements[2].SetActive(true);
        Hidden_Elements[3].SetActive(true);
    }
    #endregion
}

