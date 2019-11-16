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
    public GameObject topCorner1;
    public GameObject bottomCorner1;
    public GameObject topCorner2;
    public GameObject bottomCorner2;
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
    public Vector3 oppositeDirection2;
    public float invertVector = -1;
    Vector2 aux = new Vector2();
    Vector2 vecResBallMouse = new Vector2();

    float maxDistanceSpeed = 100.0f;
    public bool hasCrash = false;
    public bool isMoving = false;
    public bool doInerci = false;
    public bool crashSides = false;
    public bool crashTopBot = false;

    public Animator cueAnim;

    //Functions
    private void Start()
    {
        forceNewton = mass / gravity;
        Mathf.Abs(forceNewton);
        roceForce =   uCoeficient * forceNewton;
        vel = distanceSpeed * Time.deltaTime;
        camera = Camera.main;
        aux = (Vector2)(whiteBall.transform.position);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            distanceSpeed = 1.0f;
        }

        aux = (Vector2)(whiteBall.transform.position);
        vecResBallMouse = ((Vector2)transform.position + (directionTarget * (vel + restRoceForce(roceForce))));

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            cueAnim.SetBool("IsOnCharge", false);
            MousePos = (Vector2)(camera.ScreenToWorldPoint(Input.mousePosition));

            directionTarget = (Vector2)(MousePos - transform.position);
            directionTarget.Normalize();

            StartCoroutine(BallMovement(directionTarget,oppositeDirection));
            StartCoroutine(DecreaseRoceForce(roceForce));

         
        }
        if (Input.GetKey(KeyCode.Mouse0) && distanceSpeed <= maxDistanceSpeed)
        {
            cueAnim.SetBool("IsOnCharge", true);
            distanceSpeed += 0.2f;
            vel = distanceSpeed * Time.deltaTime;
        }

        if ((this.transform.position.x - whiteBallRadius) <= leftCorner.transform.position.x || (this.transform.position.x + whiteBallRadius)  >= rightCorner.transform.position.x)
        {
            Debug.Log("Chocó en los costados");
            hasCrash = true;
            doInerci = true;
            crashSides = true;
            oppositeDirection.x = (invertVector *  directionTarget.x);
            oppositeDirection.y = (directionTarget.y);

            if (doInerci)
            {
                StartCoroutine(DoInerciCorru(oppositeDirection));
            }

        }

        if ((this.transform.position.y - whiteBallRadius) <= bottomCorner1.transform.position.y || (this.transform.position.y - whiteBallRadius) <= bottomCorner2.transform.position.y || (this.transform.position.y + whiteBallRadius) >= topCorner1.transform.position.y || (this.transform.position.y + whiteBallRadius) >= topCorner2.transform.position.y)
        {
            Debug.Log("Chocó arriba o abajo");
            hasCrash = true;
            doInerci = true;
            crashTopBot = true;
            oppositeDirection.x = (directionTarget.x);
            oppositeDirection.y = (invertVector * directionTarget.y);

            if (doInerci)
            {
                StartCoroutine(DoInerciCorru(oppositeDirection));
            }
        }

    }

    //FUNCIONES Y CORRUTINAS

    IEnumerator BallMovement(Vector3 _direction, Vector3 _OpositeDirection)
    {
        cueAnim.SetBool("IsOnDischarge", true);

        yield return new WaitForSeconds(0.25f);

        cue.gameObject.SetActive(false);
        isMoving = true;

        while (isMoving == true && vel > 0 && !doInerci)
        {
           transform.position += (_direction * (vel));

           vel = vel + (restRoceForce(roceForce) * 1.5f);

           yield return new WaitForEndOfFrame();
        }

        if (vel < 0)
        {
            isMoving = false;
        }

        if (isMoving == false)
        {
            cueAnim.SetBool("IsOnDischarge", false);
            cue.gameObject.SetActive(true);
        }
    }


    IEnumerator DoInerciCorru(Vector3 _OpositeDirection)
    {
        while (doInerci)
        {
            transform.position += (_OpositeDirection * (vel));
            vel = vel + (restRoceForce(roceForce) * 1.5f);

            if (vel < 0)
            {
                doInerci = false;
                isMoving = false;
            }
            if (isMoving == false)
            {
                cueAnim.SetBool("IsOnDischarge", false);
                cue.gameObject.SetActive(true);
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void SwapBufferForVectors()
    {

        if (doInerci)
        {
            oppositeDirection2 = oppositeDirection;



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
