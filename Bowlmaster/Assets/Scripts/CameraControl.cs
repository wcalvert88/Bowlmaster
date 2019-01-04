// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CameraControl : MonoBehaviour
// {

//     [SerializeField] private Ball ball;
//     [SerializeField] private HeadPin headPin;
//     [SerializeField] private Vector3 distFrom;
//     [SerializeField] private bool followTrue;
//     private float headPinPositionZ;
//     private Vector3 startPosition;

//     void Start() {
//         ball = GameObject.FindObjectOfType<Ball>();
//         headPin = GameObject.FindObjectOfType<HeadPin>();
//         headPinPositionZ = headPin.transform.position.z;
//         distFrom = new Vector3(0f, 20f, -100f);
//         followTrue = true;
//         startPosition = gameObject.transform.position;
//     }

//     void Update() {
//         // print(ball.transform.position.z - headPin.transform.position.z);

//         if (((ball.transform.position.z - headPinPositionZ) < - 100) & (followTrue)) {
//             transform.position = ball.transform.position + distFrom;
//         } else {
//             followTrue = false;
//         }
//     }

//     public void Reset() {
//         Debug.Log("Camera reset");
//         transform.position = startPosition;
//         followTrue = true;
//     }
// }

using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	[SerializeField] public Ball ball;
	
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z <= 1829f) { // In front of head pin
			transform.position = ball.transform.position + offset;
		}
	}
}