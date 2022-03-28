using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float X;
    public float YHigh;
    public float YLow;
    private float Range;
    private float Percent = 0.5f;
    public float speed;
    private float progress;

    private Vector2 CurrentPosition;

    void Start()
    {
        Range = YHigh - YLow;
        Debug.Log(X);
        Debug.Log(Range);
        CurrentPosition = new Vector2(X, YLow + Range * Percent); 
        transform.position = CurrentPosition;
    }

    void FixedUpdate()
    {
        //transform.position = Vector2.Lerp(CurrentPosition, CurrentPosition, progress);
        //progress += speed;
    }
}
