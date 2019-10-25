using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // public GameObject whiteBall;
    private float posX;
    private float posY;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        posX = 0.0f;
        posY = 0.0f;
        transform.position = new Vector2(posX, posY);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.UpArrow))
        {
            posY += speed;
            transform.position = new Vector2(posX, posY);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            posY -= speed;
            transform.position = new Vector2(posX, posY);
        } 

       if (Input.GetKey(KeyCode.RightArrow))
        {
            posX += speed;
            transform.position = new Vector2(posX, posY);
        }
       else if (Input.GetKey(KeyCode.LeftArrow))
        {
            posX -= speed;
            transform.position = new Vector2(posX, posY);
        }
    }
}
