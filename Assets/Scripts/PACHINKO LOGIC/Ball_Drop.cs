using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball_Drop : MonoBehaviour
{
   
    public Transform DropPos;//position of where the ball will drop
    public GameObject Ball;//Ball Prefab
    bool FreeTurn;

    // Start is called before the first frame update
    void Start()
    {
        FreeTurn = true;//Player can shoot a ball
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && FreeTurn == true)//Using mouse for now in playtesting
        {
            Instantiate(Ball, DropPos.position, DropPos.rotation);//Ball Spawns
            FreeTurn = false;//player has used up their turn
        }//END OF IF INPUT STATEMENT 
    }



}
