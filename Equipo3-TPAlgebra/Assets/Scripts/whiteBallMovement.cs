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
    public float invertVector = -1;
    Vector2 aux = new Vector2();
    Vector2 vecResBallMouse = new Vector2();

    float maxDistanceSpeed = 100.0f;
    public bool isMoving = false;
    public bool firstImpact = false;
    public bool othersImpact = false;

    public Animator cueAnim;

    public bool colision = false;

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

    void FixedUpdate()
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

            StartCoroutine(BallMovement(directionTarget));
            StartCoroutine(DecreaseRoceForce(roceForce));

         
        }
        if (Input.GetKey(KeyCode.Mouse0) && distanceSpeed <= maxDistanceSpeed)
        {
            cueAnim.SetBool("IsOnCharge", true);
            distanceSpeed += 0.2f;
            vel = distanceSpeed * Time.deltaTime;
        }

      
    }

   
    //INVESTIGAR SINGLETONE Y UTILIZACION DE GIZMOS E INVOKE
    // private void OnDrawGizmos()

    //FUNCIONES Y CORRUTINAS

    IEnumerator BallMovement(Vector3 _direction)
    {
        cueAnim.SetBool("IsOnDischarge", true);

        yield return new WaitForSeconds(0.25f);

        cue.gameObject.SetActive(false);
        isMoving = true;

        while (isMoving == true && vel > 0)
        {
           transform.position += (_direction * (vel));

           vel = vel + (restRoceForce(roceForce) * 1.5f);

           yield return new WaitForEndOfFrame();
        }

        if (vel < 0)
        {
            vel = 0.0f;
            isMoving = false;
        }

        if (isMoving == false)
        {
            cueAnim.SetBool("IsOnDischarge", false);
            cue.gameObject.SetActive(true);
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
