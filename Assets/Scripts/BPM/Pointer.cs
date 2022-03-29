using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private float X;
    private float Y;
    private float Percent = 0.5f;
    private float speed = 3;
    private float XScale;
    private float  YScale;
    public bool Direction = true;
    private Vector2 Destination;

    void Start()
    {
        XScale = Screen.width/12;
        YScale = Screen.height/6;
        if (Direction)
            X = transform.parent.position.x + XScale;
        else
            X = transform.parent.position.x - XScale;
        Y = transform.parent.position.y-YScale/2;
        transform.position = new Vector2(X, Y);
        Destination = new Vector2(X, Y + YScale * Percent);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, Destination, speed*Time.deltaTime);
    }

    public void ChangeDestination(double Percent)
    {
        if (Percent > 1)
            Percent = 1;
        if (Percent < 0)
            Percent = 0;
        Destination = new Vector2(X, Y + YScale * (float)Percent);
    }
}
