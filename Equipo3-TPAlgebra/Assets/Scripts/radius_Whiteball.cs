using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radius_Whiteball : MonoBehaviour
{
    //Objects

    public GameObject white_ball;
    public GameObject point_extreme;
    public GameObject cue;
    public GameObject leftCorner;
    public GameObject rightCorner;
    public GameObject topCorner;
    public GameObject bottomCorner;
    public Camera camera;

    //Vriables

    public float white_ball_x;
    public float white_ball_y;
    public float point_extreme_x;
    public float point_extreme_y;
    public float white_ball_radius;
    public bool AlreadyClick = false;
    public bool isMoving = false;
    public float speed = 200;
    public Vector3 MousePos;

  
    //Functions

    void Update()
    {
      //  calcRad();
        if (isMoving == false)
        {
            MousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 45;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            
            AlreadyClick = true;
            cue.gameObject.SetActive(false);


        }
        if (AlreadyClick == true)
        {
            isMoving = true;
            this.transform.position = Vector3.MoveTowards(this.transform.position, MousePos, speed * Time.deltaTime);
        }
        if (this.transform.position == MousePos)
        {
            isMoving = false;
            AlreadyClick = false;
            cue.gameObject.SetActive(true);
        }
        if (this.transform.position.x - this.white_ball_radius <= leftCorner.transform.position.x || this.transform.position.x + this.white_ball_radius >= rightCorner.transform.position.x)
        {
            isMoving = false;
            AlreadyClick = false;
            cue.gameObject.SetActive(true);
        }
        if (this.transform.position.y - this.white_ball_radius <= bottomCorner.transform.position.y || this.transform.position.y + this.white_ball_radius >= topCorner.transform.position.y)
        {
            isMoving = false;
            AlreadyClick = false;
            cue.gameObject.SetActive(true);
        }
    }   

    void calcRad()
    {

        white_ball_x = white_ball.gameObject.transform.position.x;
        white_ball_y = white_ball.gameObject.transform.position.y;
        point_extreme_x = point_extreme.gameObject.transform.position.x;
        point_extreme_y = point_extreme.gameObject.transform.position.y;

        //white_ball_radius = (white_ball_x + white_ball_y) - (point_extreme_x + point_extreme_y);

        //white_ball_radius = Mathf.Abs(white_ball_radius);

    }

}
