using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] public Vector3 launchSpeed;
    public bool inPlay = false;
    
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private AudioSource audioSource;

    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Launch(Vector3 velocity) {
        inPlay = true;
        
        launchSpeed = velocity;
        rigidBody.useGravity = true;
        rigidBody.freezeRotation = false;
        rigidBody.velocity = velocity;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();    
    }

    public void Reset() {
        inPlay = false;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.freezeRotation = true;
        transform.rotation = startRotation;
        transform.position = startPosition;
        
    }
}
