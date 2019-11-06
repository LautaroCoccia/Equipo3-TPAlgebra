using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_Triangle : MonoBehaviour
{
    public GameObject triangle;
    public GameObject[] balls;
    const int BALLCANT = 16;
    public float ballRadius = 2.555f;


    void Start()
    {
        balls[1].transform.position = new Vector2(-(ballRadius*2), 0);
        for(int i =2; i< BALLCANT; i++)
        {
            for (int j = 2; j < BALLCANT; j++)
            {
            }
            balls[i].transform.position = new Vector2(, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
