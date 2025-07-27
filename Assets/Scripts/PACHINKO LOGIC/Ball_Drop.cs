using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball_Drop : MonoBehaviour
{
    
    float BallDirection;
    public Rigidbody2D BallForceBody;//adds force to the ball
    public Transform DropPos;//position of where the ball will drop
    public GameObject Ball;//Ball Prefab


    // Start is called before the first frame update
    void Start()
    {
        BallForceBody = Ball.GetComponent<Rigidbody2D>();//Rigidbody component is obtained from ball prefab
        Direction_Dice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Using mouse for now in playtesting
        {
            Instantiate(Ball, DropPos.position, DropPos.rotation);//Ball Spawns

            //Gravity
            Physics2D.gravity = new Vector2(BallDirection, -5);
        }//END OF IF INPUT STATEMENT 
    }

    public void Direction_Dice()
    {
        int randomizer = Random.Range(1, 3);
        Debug.Log(randomizer.ToString());
        switch (randomizer)
        {
            case 1:
                BallDirection = -1;
                break;
            case 2:
                BallDirection = 1;
                break;
            case 3:
                BallDirection = 0;
                break;
        }
    }


}
