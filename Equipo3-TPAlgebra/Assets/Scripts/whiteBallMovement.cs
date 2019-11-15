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
    float maxDistanceSpeed = 100.0f;
    public bool changeSideX = false;
    public bool changeSideY = false;

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
           // if (changeSideX == false || changeSideY == false)
            {
                StartCoroutine(BallMovement(directionTarget));
                StartCoroutine(DecreaseRoceForce(roceForce));
            }
            /*if (changeSideY == false && changeSideX == true)
            {
                StartCoroutine(BallMovementNegX(directionTarget));
                StartCoroutine(DecreaseRoceForce(roceForce));
            }
            if (changeSideY == true && changeSideX == false)
            {
                StartCoroutine(BallMovementNegY(directionTarget));
                StartCoroutine(DecreaseRoceForce(roceForce));
            }*/
        }
        if (Input.GetKey(KeyCode.Mouse0) && distanceSpeed <= maxDistanceSpeed)
        {
            cueAnim.SetBool("IsOnCharge", true);
            distanceSpeed += 0.2f;
        }

        if ((this.transform.position.x - whiteBallRadius) <= leftCorner.transform.position.x || (this.transform.position.x + whiteBallRadius) >= rightCorner.transform.position.x)
        {
          //  changeSideX = !changeSideX;
            Debug.Log("Chocó en los costados");
        }

        if ((this.transform.position.y - whiteBallRadius) <= bottomCorner1.transform.position.y || (this.transform.position.y - whiteBallRadius) <= bottomCorner2.transform.position.y || (this.transform.position.y + whiteBallRadius) >= topCorner1.transform.position.y || (this.transform.position.y + whiteBallRadius) >= topCorner2.transform.position.y)
        {
           // changeSideY = !changeSideY;
            Debug.Log("Chocó arriba o abajo");
        }
        
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

    /*
    IEnumerator BallMovementNegX(Vector3 _direction)
    {
        cueAnim.SetBool("IsOnDischarge", true);

        Debug.Log("llegó");
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
            _direction.x = _direction.x * invertVector;
            yield return new WaitForEndOfFrame();
        }

    }

    IEnumerator BallMovementNegY(Vector3 _direction)
    {
        cueAnim.SetBool("IsOnDischarge", true);

        Debug.Log("llegó");
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
            _direction.y = _direction.y * invertVector;
            yield return new WaitForEndOfFrame();
        }

    }
    */
}
