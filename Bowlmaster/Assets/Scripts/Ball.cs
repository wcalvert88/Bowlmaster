using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] public Vector3 launchSpeed;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
        Launch();
    }

    public void Launch() {
        rigidBody.velocity = launchSpeed;
        audioSource.Play();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
