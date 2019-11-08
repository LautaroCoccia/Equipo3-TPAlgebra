using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue_logicMovement : MonoBehaviour
{
    public GameObject whiteBall;
    public GameObject cue_extreme;
    public GameObject impact_point;

    public float vel;
    public float mass;
    public float speedForce = 0.5f;
    static bool isBallMoving = false;

    void Update()
    {

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2((mousePosition.x - whiteBall.transform.position.x), (mousePosition.y - whiteBall.transform.position.y));
        whiteBall.gameObject.transform.up = direction;

        //Setea la posicion del punto de impacto a un vector2.
        Vector2 pos_impactPoint = new Vector2(impact_point.transform.position.x, impact_point.transform.position.y);

        Vector2 impactPoint = new Vector2(mousePosition.x, mousePosition.y);

        pos_impactPoint = impactPoint;
        impact_point.transform.position = pos_impactPoint;

        Vector2 ballPos = new Vector2(whiteBall.transform.position.x, whiteBall.transform.position.y);

        if (Input.GetMouseButtonDown(1) || isBallMoving)
        {
            isBallMoving = true;
            Test_ball_movement(ballPos,direction);
        }

    }

    void Test_ball_movement(Vector2 ballPos, Vector2 direction)
    {
        whiteBall.gameObject.transform.position = new Vector2((ballPos.x + (speedForce * Time.deltaTime)) + (direction.x*Time.deltaTime), (ballPos.y + (speedForce * Time.deltaTime)) + (direction.y * Time.deltaTime));
    }

}
