using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Randomizer : MonoBehaviour
{
    public GameObject[] MapIndex = new GameObject[2];

    // Update is called once per frame
    void Start()
    {
        int Randomizer = Random.Range(0, 5);  

        if(Randomizer <= 2)
        {
            MapIndex[1].SetActive(false);
            MapIndex[0].SetActive(true);
        }
        else if(Randomizer > 2 || Randomizer == 5)
        {
            MapIndex[0].SetActive(false);
            MapIndex[1].SetActive(true);
        }

        Debug.Log(Randomizer);
    }
}
