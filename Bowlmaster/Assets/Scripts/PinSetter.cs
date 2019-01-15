using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    [SerializeField] public Text standingDisplay;
    [SerializeField] private Ball ball;
    private int lastStandingCount = -1;
    public GameObject pinSet;

    private int lastSettledCount = 10;
    
    private bool ballLeftBox = false;
    private float lastChangeTime;

    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster();

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        if (ballLeftBox) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    public void SetBallLeftBox() {
        ballLeftBox = true;
    }

    public void RaisePins() {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
            
        }
    }

    public void LowerPins() {
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins() {
        Instantiate(pinSet, new Vector3(0, 45, 1829), Quaternion.identity);
        foreach(Pin pins in GameObject.FindObjectsOfType<Pin>()) {
            pins.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void UpdateStandingCountAndSettle() {
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
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        
        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if(action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndTurn) {
            throw new UnityException("Don't know how to handle end game yet");
        }

        ball.Reset();
        lastStandingCount = -1; // Indicates new frame
        ballLeftBox = false;
        standingDisplay.color = Color.green;
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

    void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        
        if (thingHit.GetComponent<Ball>()) {

            standingDisplay.color = Color.red;
            ballLeftBox = true;
        }
    }
}
