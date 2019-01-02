using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Ball ball;
    [SerializeField] private HeadPin headPin;
    [SerializeField] private Vector3 distFrom;
    [SerializeField] private bool followTrue;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
        headPin = GameObject.FindObjectOfType<HeadPin>();
        distFrom = new Vector3(0f, 20f, -100f);
        followTrue = true;
    }

    void Update() {
        print(ball.transform.position.z - headPin.transform.position.z);

        if (((ball.transform.position.z - headPin.transform.position.z) < - 100) & (followTrue)) {
            transform.position = ball.transform.position + distFrom;
        } else {
            followTrue = false;
        }
    }
}
