using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prizepool : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Yellow")//if ball goes into yellow slot 
        {
            Debug.Log("Normal Prize");
        }
        if (collision.tag == "Orange")//if ball goes into the orange slot
        {
            Debug.Log("Rare prize");
        }
        if (collision.tag == "Red")//if ball goes into the Red slot 
        {
            Debug.Log("Super rare prize");
        }
    }
}
