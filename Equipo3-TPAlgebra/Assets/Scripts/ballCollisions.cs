using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollisions : MonoBehaviour
{
    // GameObjects

    public GameObject whiteBall;
    public GameObject[] corners;
    public GameObject[] balls;
    public GameObject[] walls;

    public radiusOtherBalls ballsRads;
    public whiteBallMovement whiteBallRad;

    //Variables
    const int cornersCant = 6;
    const int wallsCant = 6;
    public float[] distanciasCorners = new float[cornersCant];
    public float[] distanciasWalls = new float[wallsCant];
    private float allCornerRadius;

    Vector2 pointWall;

    void Update()
    {
        allCornerRadius = ballsRads.otherBallRadius;

        CalcCollisionCorners();

        CalcCollisionWalls();

        //calcCollisionBalls();
    }

    void CalcCollisionCorners()
    {

        for (int i = 0; i < cornersCant; i++)
        {
            distanciasCorners[i] = Mathf.Sqrt(Mathf.Pow((whiteBall.transform.position.x - corners[i].transform.position.x), 2) + Mathf.Pow((whiteBall.transform.position.y - corners[i].transform.position.y), 2));
        }

        if (distanciasCorners[0] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Superior Izquierdo....");
        }
        else if (distanciasCorners[1] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Inferior Izquierdo....");
        }
        else if (distanciasCorners[2] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Central Superior....");
        }
        else if (distanciasCorners[3] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Central Inferior....");
        }
        else if (distanciasCorners[4] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Superior Derecho....");
        }
        else if (distanciasCorners[5] < (allCornerRadius))
        {
            Debug.Log("La Bola blanca entro en el agujero Inferior Derecho....");
        }

    }

    void CalcCollisionWalls()
    {



        /*
         for (int i = 0; i < wallsCant; i++)
         {
             pointWall = new Vector2(wallPoint[i].transform.position.x, wallPoint[i].transform.position.y);

             pointWall.x = whiteBall.gameObject.transform.position.x;

             if (pointWall.x < walls[i].transform.position.x) pointWall.x = walls[i].transform.position.x;
             if (pointWall.x > walls[i].transform.position.x + walls[i].transform.localScale.x) pointWall.x = walls[i].transform.position.x + walls[i].transform.localScale.x;

             pointWall.y = whiteBall.gameObject.transform.position.y;

             if (pointWall.y < walls[i].transform.position.y) pointWall.y = walls[i].transform.position.y;
             if (pointWall.y > walls[i].transform.position.y + walls[i].transform.localScale.y) pointWall.y = walls[i].transform.position.y + walls[i].transform.localScale.y;

             distanciasWalls[i] = Mathf.Sqrt(Mathf.Pow(whiteBall.transform.position.x - pointWall.x, 2) + Mathf.Pow(whiteBall.transform.position.y - pointWall.y, 2));
         }

         if (distanciasWalls[0] < whiteBallRad.whiteBallRadius)
         {
             Debug.Log("La bola blanca colisiono con la pared Izquierda...");
         }
         else if (distanciasWalls[1] < whiteBallRad.whiteBallRadius)
         {
             Debug.Log("La bola blanca colisiono con la pared Derecha...");
         }
         */
    }

    /*
    void calcCollisionBalls()
    {
        distancias = Mathf.Sqrt(Mathf.Pow((whiteBall.transform.position.x - balls[0].transform.position.x), 2) + Mathf.Pow((whiteBall.transform.position.y - balls[0].transform.position.y), 2));

        if (distancias < (ballsRads.otherBallRadius + whiteBallRad.whiteBallRadius))
        {
            Debug.Log("La Bola blanca impacto con otra bola....");
        }

    }
    */
}
