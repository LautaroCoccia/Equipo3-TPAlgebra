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

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2 ((mousePosition.x - whiteBall.transform.position.x),(mousePosition.y - whiteBall.transform.position.y));
        whiteBall.gameObject.transform.up= direction;

        //Setea la posicion del punto de impacto a un vector2.
        Vector2 pos_impactPoint = new Vector2(impact_point.transform.position.x, impact_point.transform.position.y);

        Vector2 impactPoint = new Vector2(mousePosition.x, mousePosition.y);

        pos_impactPoint = impactPoint;
        impact_point.transform.position = pos_impactPoint;

    }

    void calcVel()
    {
        //vel = 

    }

}
