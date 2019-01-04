using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] public float standingThreshold = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name + IsStanding());
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
