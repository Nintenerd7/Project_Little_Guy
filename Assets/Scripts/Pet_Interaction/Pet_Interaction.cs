using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_Interaction : MonoBehaviour
{
    public GameObject[] Hidden_Elements = new GameObject[4];
    public GameObject hand;
    public Game Game_Manager;

    public void HeadpatButton()
    {
        StartCoroutine(Headpat());//player gives headpats to the pet.
        Debug.Log("*Pat Pat*");
    }

    public IEnumerator Headpat()
    {
        HideButtons();//hides buttons
        hand.SetActive(true);//headpats are there 
        yield return new WaitForSeconds(1);//waits for 1 second
        //possible update to happiness here
        hand.SetActive(false);//headpats are not there.
        ShowButtons();//shows buttons
    }

    //sets buttons to false
    public void HideButtons()
    {
      Hidden_Elements[0].SetActive(false);
      Hidden_Elements[1].SetActive(false);
      Hidden_Elements[2].SetActive(false);
      Hidden_Elements[3].SetActive(false);
    }
    //sets buttons to true
    public void ShowButtons()
    {
        Hidden_Elements[0].SetActive(true);
        Hidden_Elements[1].SetActive(true);
        Hidden_Elements[2].SetActive(true);
        Hidden_Elements[3].SetActive(true);
    }
}

