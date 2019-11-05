using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radius_Whiteball : MonoBehaviour
{
    //Objects

    public GameObject white_ball;
    public GameObject point_extreme;

    //Vriables

    public float white_ball_x;
    public float white_ball_y;
    public float point_extreme_x;
    public float point_extreme_y;
    public float white_ball_radius;
  
    //Functions

    void Update()
    {
        calcRad();
    }

    void calcRad()
    {

        white_ball_x = white_ball.gameObject.transform.position.x;
        white_ball_y = white_ball.gameObject.transform.position.y;
        point_extreme_x = point_extreme.gameObject.transform.position.x;
        point_extreme_y = point_extreme.gameObject.transform.position.y;

        white_ball_radius = (white_ball_x + white_ball_y) - (point_extreme_x + point_extreme_y);

        white_ball_radius = Mathf.Abs(white_ball_radius);

    }

}
