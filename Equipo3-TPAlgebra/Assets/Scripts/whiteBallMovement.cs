using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteBallMovement : MonoBehaviour
{
    //Objects

    public GameObject whiteBall;
    public GameObject cue;
    public GameObject leftCorner;
    public GameObject rightCorner;
    public GameObject topCorner;
    public GameObject bottomCorner;
    public Camera camera;

    //Vriables

        //WhiteBall & OthersValues
        public float whiteBallX;
        public float whiteBallY;
        public float whiteBallRadius;

        public float mass;
        private float gravity = 9.8f;
        private float vel;
        private float uCoeficient = 0.20f;
        private float forceNewton;
        private float roceForce;

        //Movement
        public bool AlreadyClick = false;
        public bool isMoving = false;
        public bool hasCrash = false;
        public float distanceSpeed;

        //Vectors & values
        public Vector3 MousePos;
        public Vector3 directionTarget;
        public Vector3 oppositeDirection;
        float invertVector = -1;


    //Functions
    private void Start()
    {
        forceNewton = mass * gravity;
        vel = distanceSpeed * Time.deltaTime;
        roceForce = uCoeficient * forceNewton;
    }
   
    void Update()
    {
        calcRad();

        if (isMoving == false)
        {
            MousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            MousePos.z = 45;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            
            AlreadyClick = true;

            directionTarget = MousePos;

            oppositeDirection = (invertVector * directionTarget);
            oppositeDirection.z = 45;

            cue.gameObject.SetActive(false);

        }
        if (AlreadyClick == true)
        {
            isMoving = true;
            whiteBall.transform.position = Vector3.MoveTowards(whiteBall.transform.position, directionTarget, vel );
        }
        if (hasCrash == true)
        {
            whiteBall.transform.position = Vector3.MoveTowards(whiteBall.transform.position, oppositeDirection, vel);
        }

        
        if (whiteBall.transform.position == directionTarget ||whiteBall.transform.position == oppositeDirection)
        {
            isMoving = false;
            AlreadyClick = false;
            hasCrash = false;
            cue.gameObject.SetActive(true);
        }

        //Colision no RANCIA (Other Script)

        //Colision RANCIA

        if ((whiteBallX - whiteBallRadius) <= leftCorner.transform.position.x || (whiteBallX + whiteBallRadius) >= rightCorner.transform.position.x)
        {

            isMoving = false;
            AlreadyClick = false;
            hasCrash = true;

            if (whiteBall.transform.position == oppositeDirection)
            {
                cue.gameObject.SetActive(true);
            }
            else if (whiteBall.transform.position != oppositeDirection)
            {
                cue.gameObject.SetActive(false);
            }

        }

        if ((whiteBallY - whiteBallRadius) <= bottomCorner.transform.position.y || (whiteBallY + whiteBallRadius) >= topCorner.transform.position.y)
        {
            isMoving = false;
            AlreadyClick = false;
            hasCrash = true;

            if (whiteBall.transform.position == oppositeDirection)
            {
                cue.gameObject.SetActive(true);
            }
            else if (whiteBall.transform.position != oppositeDirection)
            {
                cue.gameObject.SetActive(false);
            }

        }
    }   

    void calcRad()
    { 
        whiteBallX = whiteBall.gameObject.transform.position.x;
        whiteBallY = whiteBall.gameObject.transform.position.y;
        whiteBallRadius = 0.2555f;
    }

}
