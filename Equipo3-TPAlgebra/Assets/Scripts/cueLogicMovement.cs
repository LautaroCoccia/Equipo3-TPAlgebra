using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueLogicMovement : MonoBehaviour
{
    public GameObject whiteBall;
    public GameObject cueExtreme;
    public GameObject impactPoint;
    public Color linecolor = Color.white;

    void Update()
    {
        Vector2 ballPos = new Vector2(whiteBall.transform.position.x, whiteBall.transform.position.y);

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2((mousePosition.x - whiteBall.transform.position.x), (mousePosition.y - whiteBall.transform.position.y));

        whiteBall.gameObject.transform.up = direction;

        //Setea la posicion del punto de impacto a un vector2.
        Vector2 pos_impactPoint = new Vector2(impactPoint.transform.position.x, impactPoint.transform.position.y);

        Vector2 impactToMouse = new Vector2(mousePosition.x, mousePosition.y);

        pos_impactPoint = impactToMouse;
        impactPoint.transform.position = pos_impactPoint;

        Debug.DrawLine(ballPos, pos_impactPoint, linecolor);
        

    }

}
