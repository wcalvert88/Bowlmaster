using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] public float standingThreshold = 3f;
    public float distanceToRaise = 40f;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RaiseIfStanding() {
        // raise standing pins only by distanceToRaise
        
        if(IsStanding()) {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0f, distanceToRaise, 0f), Space.World);
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
    }

    public void Lower() {
        transform.Translate(new Vector3(0f, -distanceToRaise, 0f),  Space.World);
        rigidBody.useGravity = true;
    }

    void OnCollisionEnter(Collision collider) {
        Debug.Log("Pin was hit by " + collider.gameObject.name, collider.gameObject);
    }

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if ((tiltInX < standingThreshold || (tiltInX <= 360f && tiltInX >= 360f - standingThreshold)) || (tiltInZ < standingThreshold || (tiltInZ <= 360f && tiltInZ >= 360f - standingThreshold))) {
            return true;
        } else {
            return false;
        }
    }
}
