using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radius_otherBalls : MonoBehaviour
{
    //Objects

    public GameObject other_ball;
    public GameObject point_extreme;

    //Variables

    public float other_ball_x;
    public float other_ball_y;
    public float point_extreme_x;
    public float point_extreme_y;
    public float other_ball_radius;

    //Functions

    void Update()
    {
        calcRad();
    }

    void calcRad()
    {

        other_ball_x = other_ball.gameObject.transform.position.x;
        other_ball_y = other_ball.gameObject.transform.position.y;
        point_extreme_x = point_extreme.gameObject.transform.position.x;
        point_extreme_y = point_extreme.gameObject.transform.position.y;

        other_ball_radius = (other_ball_x + other_ball_y) - (point_extreme_x + point_extreme_y);

        other_ball_radius = Mathf.Abs(other_ball_radius);

    }

}
