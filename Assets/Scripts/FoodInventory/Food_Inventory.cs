using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] Food_Items = new int[4];

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Food_Items.Length; i++)
        {
            Collect_Food(1, Food_Items[i]);//test this out
            Debug.Log(Food_Items[i]);
        }

    }

    public void Collect_Food(int FoodCount, int ArrayValue)
    {
        FoodCount++;
    }
}
