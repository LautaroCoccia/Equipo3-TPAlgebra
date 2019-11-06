using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue_logicCollision : MonoBehaviour
{
    public GameObject cue;
    public GameObject target_whiteBall;

    float pos_cue_X;
    float pos_cue_Y;

    float pos_ball_X;
    float pos_ball_Y;

    void Update()
    {
        pos_ball_X = target_whiteBall.transform.position.x;
        pos_ball_Y = target_whiteBall.transform.position.y;

        pos_cue_X = cue.transform.position.x;
        pos_cue_Y = cue.transform.position.y;




    }
}
