using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    [SerializeField] public Text standingDisplay;

    private GameManager gameManager;

    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private bool ballLeftBox = false;
    private float lastChangeTime;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        standingDisplay.text = CountStanding().ToString();
        if (ballLeftBox) {
            UpdateStandingCountAndSettle();
            
        }
    }

    public void Reset() {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Ball") {
            ballLeftBox = true;
            standingDisplay.color = Color.red;
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

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; // Indicates new frame
        ballLeftBox = false;
        Debug.Log("Is this working");
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
}
