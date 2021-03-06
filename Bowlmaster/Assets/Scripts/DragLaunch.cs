﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour
{
    private Ball ball;
    private float startTime, endTime;
    private Vector3 dragStart, dragEnd;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void DragStart() {
        // Capture time & position of drag start
        if (!ball.inPlay) {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }

    }

    public void DragEnd() {
        // Launch the ball
        if(!ball.inPlay){
            dragEnd = Input.mousePosition;
            endTime = Time.time;
            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(Mathf.Clamp(launchSpeedX, -2000f, 2000f), 0, Mathf.Clamp(launchSpeedZ, 0f, 2000f));
            ball.Launch(launchVelocity);
        }
    }

    public void MoveStart(float amount) {
        
        if (!ball.inPlay) {
            Debug.Log("Ball moved " + amount);
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -150f, 150f);
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
    }

}
