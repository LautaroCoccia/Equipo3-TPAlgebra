using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollisions : MonoBehaviour
{
    // GameObjects

    public GameObject whiteBall;
    public GameObject[] corners;
    private GameObject[] balls;
    public makeTriangle makeTriangle;
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
    float distance;

    Vector2 pointWall;

    private void Start()
    {
        balls = makeTriangle.balls;
    }

    void FixedUpdate()
    {
        allCornerRadius = ballsRads.otherBallRadius;
    
        calcCollisionBalls();

        CalcCollisionCorners();

        CalcCollisionWalls();

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

    public void CalcCollisionWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            switch (walls[i].colliderEdge)
            {
                case Wall.ColliderEdge.BOTTOM:
                    if (whiteBall.transform.position.y + whiteBallPropieties.whiteBallRadius <= (walls[i].transform.position.y))
                    {                    
                        whiteBallPropieties.directionTarget = new Vector2(whiteBallPropieties.directionTarget.x, (whiteBallPropieties.directionTarget.y * (whiteBallPropieties.invertVector)));
                        whiteBallPropieties.transform.position = new Vector2(whiteBallPropieties.aux.x, whiteBallPropieties.aux.y + whiteBallPropieties.whiteBallRadius);
                        whiteBallPropieties.vel = whiteBallPropieties.vel / 1.5f;                   
                    }
                    break;
                case Wall.ColliderEdge.UP:
                    if (whiteBall.transform.position.y + whiteBallPropieties.whiteBallRadius >= (walls[i].transform.position.y))
                    {
                        whiteBallPropieties.directionTarget = new Vector2(whiteBallPropieties.directionTarget.x, (whiteBallPropieties.directionTarget.y * (whiteBallPropieties.invertVector)));
                        whiteBallPropieties.transform.position = new Vector2(whiteBallPropieties.aux.x, whiteBallPropieties.aux.y - whiteBallPropieties.whiteBallRadius);
                        whiteBallPropieties.vel = whiteBallPropieties.vel / 1.5f;

                    }
                    break;
                case Wall.ColliderEdge.RIGHT:
                    if (whiteBall.transform.position.x + whiteBallPropieties.whiteBallRadius >= (walls[i].transform.position.x))
                    {
                        whiteBallPropieties.directionTarget = new Vector2((whiteBallPropieties.directionTarget.x * (whiteBallPropieties.invertVector)), whiteBallPropieties.directionTarget.y);
                        whiteBallPropieties.transform.position = new Vector2(whiteBallPropieties.aux.x - whiteBallPropieties.whiteBallRadius, whiteBallPropieties.aux.y);
                        whiteBallPropieties.vel = whiteBallPropieties.vel / 1.5f;

                    }
                    break;
                case Wall.ColliderEdge.LEFT:
                    if ((whiteBall.transform.position.x + whiteBallPropieties.whiteBallRadius) <= (walls[i].transform.position.x))
                    {
                        whiteBallPropieties.directionTarget = new Vector2((whiteBallPropieties.directionTarget.x * (whiteBallPropieties.invertVector)), whiteBallPropieties.directionTarget.y);                  
                        whiteBallPropieties.transform.position = new Vector2(whiteBallPropieties.aux.x + whiteBallPropieties.whiteBallRadius, whiteBallPropieties.aux.y);              
                        whiteBallPropieties.vel = whiteBallPropieties.vel / 1.5f;

                    }
                    break;
            }
        }

    }

    void calcCollisionBalls()
    {
        for (int i = 1; i < balls.Length; i++)
        {
            distance = Mathf.Sqrt(Mathf.Pow((whiteBall.transform.position.x - balls[i].transform.position.x), 2) + Mathf.Pow((whiteBall.transform.position.y - balls[i].transform.position.y), 2));

            if (distance < (ballsRads.otherBallRadius + whiteBallPropieties.whiteBallRadius))
            {
                Debug.Log("La Bola blanca impacto con otra bola....");
            }
            else
            {
                //Debug.Log("No colisiona");
            }
        }
    }
    
}
