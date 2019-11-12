using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusOtherBalls : MonoBehaviour
{
    //Objects

    public GameObject otherBall;
    public GameObject pointExtreme;
    //Variables

    public float otherBallX;
    public float otherBallY;
    public float pointExtremeX;
    public float pointExtremeY;
    public float otherBallRadius;

    //Functions

    void Update()
    {
        calcRad();
    }

    void calcRad()
    {

        otherBallX = otherBall.gameObject.transform.position.x;
        otherBallY = otherBall.gameObject.transform.position.y;
        pointExtremeX = pointExtreme.gameObject.transform.position.x;
        pointExtremeY = pointExtreme.gameObject.transform.position.y;

        otherBallRadius = (otherBallX + otherBallY) - (pointExtremeX + pointExtremeY);

        otherBallRadius = Mathf.Abs(otherBallRadius);

    }

}
