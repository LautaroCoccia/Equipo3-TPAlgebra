using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public enum ColliderEdge
    {
        BOTTOM, 
        UP,
        RIGHT,
        LEFT
    }

    public ColliderEdge colliderEdge;
    public float wallWidth;
    public float wallHeight;
}
