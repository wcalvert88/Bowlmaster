using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    [SerializeField] public Text standingDisplay;
    [SerializeField] private Ball ball;
    public int lastStandingCount = -1;
    
    private bool ballEnteredBox = false;
    private float lastChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            CheckStanding();
        }
    }

    void CheckStanding() {
        // Update the lastStandingCount
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) {
            PinsHaveSettled();
        }
        // Call PinsHaveSettled() when they have
}

    void PinsHaveSettled() {
        ball.Reset();
        lastStandingCount = -1; // Indicates new frame
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }
    void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        
        if (thingHit.GetComponent<Ball>()) {

            standingDisplay.color = Color.red;
            ballEnteredBox = true;
        }
    }

    void OnTriggerExit(Collider other) {
        
        if (other.name == "Ball") {
            return;
        }
        
        if (other.transform.parent.GetComponent<Pin>()) {
            Debug.Log(other.transform.parent.name + " no longer in pin setter");
            Destroy(other.transform.parent.gameObject);
        }
    }
    public int CountStanding() {
        int standingPins = 0;
        Pin[] pins = GameObject.FindObjectsOfType<Pin>();
        foreach (Pin pin in pins)
        {
            if(pin.IsStanding()) {
                standingPins++;
            }
        }
        return standingPins;
    }
}
