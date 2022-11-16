using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    
    public static float leftBoundary = -10.5f;
    public static float rightBoundary = 10.5f;


    public double frontBoundary = 6f;
    public double backBoundary = 6f;


    void FixedUpdate() {
        frontBoundary = base.transform.position.z + 6.5;
        backBoundary = base.transform.position.z - 9;
    }

}
