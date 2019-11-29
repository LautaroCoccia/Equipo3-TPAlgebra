using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollisions : MonoBehaviour
{
    // GameObjects

    public GameObject whiteBall;
    public GameObject[] corners;
    public GameObject[] balls;
    public Wall[] walls;

    public radiusOtherBalls ballsRads;
    public whiteBallMovement whiteBallPropieties;

    //Variables
    const int cornersCant = 6;
    const int wallsCant = 6;
    public float[] distanciasCorners = new float[cornersCant];
    public float[] distanciasWalls = new float[wallsCant];
    private float allCornerRadius;
    bool hasCrash = false;

    Vector2 pointWall;

    void FixedUpdate()
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

            if (distanciasCorners[i] < (allCornerRadius))
            {
                Debug.Log("La Bola blanca entro en un agujero....");
            }
        }
    }

    void CalcCollisionWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            switch (walls[i].colliderEdge)
            {
                case Wall.ColliderEdge.BOTTOM:
                    if (whiteBall.transform.position.y + whiteBallPropieties.whiteBallRadius <= (walls[i].transform.position.y))
                    {
                        whiteBallPropieties.directionTarget = new Vector2(whiteBallPropieties.directionTarget.x, (whiteBallPropieties.directionTarget.y * (whiteBallPropieties.invertVector)));
                    }
                    break;
                case Wall.ColliderEdge.UP:
                    if (whiteBall.transform.position.y + whiteBallPropieties.whiteBallRadius >= (walls[i].transform.position.y))
                    {
                        whiteBallPropieties.directionTarget = new Vector2(whiteBallPropieties.directionTarget.x, (whiteBallPropieties.directionTarget.y * (whiteBallPropieties.invertVector)));
                    }
                    break;
                case Wall.ColliderEdge.RIGHT:
                    if (whiteBall.transform.position.x + whiteBallPropieties.whiteBallRadius >= (walls[i].transform.position.x))
                    {
                        
                        whiteBallPropieties.directionTarget = new Vector2((whiteBallPropieties.directionTarget.x * (whiteBallPropieties.invertVector)), whiteBallPropieties.directionTarget.y);
                    }
                    break;
                case Wall.ColliderEdge.LEFT:
                    if ((whiteBall.transform.position.x + whiteBallPropieties.whiteBallRadius) <= (walls[i].transform.position.x))
                    {
                        whiteBallPropieties.directionTarget = new Vector2((whiteBallPropieties.directionTarget.x * (whiteBallPropieties.invertVector)), whiteBallPropieties.directionTarget.y);
                    }
                    break;
            }
        }


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
