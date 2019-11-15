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
    public float whiteBallRadius = 0.2555f;

    public float mass;
    public float distanceSpeed;
    private float gravity = -9.8f;
    public float vel;
    private float uCoeficient = 0.15f;
    public float forceNewton;
    public float roceForce;

    //Movement
    //Vectors & values
    public Vector3 MousePos;
    public Vector2 directionTarget;
    public Vector3 oppositeDirection;
    public float invertVector = -1;
    Vector2 aux = new Vector2();
    float maxDistanceSpeed = 100.0f;

    public Animator cueAnim;

    //Functions
    private void Start()
    {
        forceNewton = mass / gravity;
        Mathf.Abs(forceNewton);
        roceForce =   uCoeficient * forceNewton;
        camera = Camera.main;
        aux = (Vector2)(whiteBall.transform.position);
    }

    void Update()
    {
        vel = distanceSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            distanceSpeed = 1.0f;
        }

        aux = (Vector2)(whiteBall.transform.position);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            cueAnim.SetBool("IsOnCharge", false);
            
            MousePos = (Vector2)(camera.ScreenToWorldPoint(Input.mousePosition));
            directionTarget = (Vector2)(MousePos - transform.position);
            directionTarget.Normalize();
            StartCoroutine(BallMovement(directionTarget));
            StartCoroutine(DecreaseRoceForce(roceForce));

        }
        if (Input.GetKey(KeyCode.Mouse0) && distanceSpeed <= maxDistanceSpeed)
        {
            cueAnim.SetBool("IsOnCharge", true);
            distanceSpeed += 0.2f;
        }

        /*

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

        }*/
    }

    void calcNewDirection()
    {
        
    }

    IEnumerator BallMovement(Vector3 _direction)
    {
        cueAnim.SetBool("IsOnDischarge", true);

        yield return new WaitForSeconds(0.25f);

        cue.gameObject.SetActive(false);

        for (int i = 0; i < 25; i++)
        {
            transform.position += (_direction * (vel + (restRoceForce(roceForce))));

            if (i == 24)
            {
                cueAnim.SetBool("IsOnDischarge", false);
                cue.gameObject.SetActive(true);
            }
            yield return new WaitForEndOfFrame();
        }

    }

    IEnumerator DecreaseRoceForce(float roceForce)
    {
       while(roceForce > 0)
        {
            restRoceForce(roceForce);
            yield return new WaitForSeconds(0.5f);
        }

    }

    float restRoceForce(float roceForce)
    {
        float rForce = 0;

        rForce = roceForce * (Mathf.Pow(Time.deltaTime,2));

        return rForce;
    }

}
