using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTriangle : MonoBehaviour
{
    public GameObject triangle;
    public GameObject[] balls;
    public radiusOtherBalls RadiusOtherBalls;

    const int BALLCANT = 16;
    public float ballRadius = 0.2555f;

    void Start()
    {
        
        for(int i =1; i< BALLCANT; i++)
        {
            //for (int j = 1; j < BALLCANT; j++)
            //{
            //    balls[i].SetActive(true);
            //} 
          
        }
        balls[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
