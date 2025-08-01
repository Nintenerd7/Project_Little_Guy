using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Randomizer : MonoBehaviour
{
    public GameObject[] MapIndex = new GameObject[3];//contains two of the pachinko maps

    // Update is called once per frame
    void Start()
    {
        int Randomizer = Random.Range(0, 7);  //randomizes maps

        if(Randomizer <= 2)
        {
            MapIndex[2].SetActive(false);
            MapIndex[1].SetActive(false);
            MapIndex[0].SetActive(true);
        }
        else if(Randomizer > 2 && Randomizer <= 4)
        {
            MapIndex[2].SetActive(false);
            MapIndex[0].SetActive(false);
            MapIndex[1].SetActive(true);
        }
        else if(Randomizer > 4)
        {
            MapIndex[2].SetActive(true);
            MapIndex[0].SetActive(false);
            MapIndex[1].SetActive(false);
        }
        

        Debug.Log(Randomizer);
    }
}
