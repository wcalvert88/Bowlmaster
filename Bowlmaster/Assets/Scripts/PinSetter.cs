using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    [SerializeField] public Text standingDisplay;
    [SerializeField] public Ball ball;
    private bool ballEnteredBox = false;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(CountStanding());
        standingDisplay.text = CountStanding().ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        
        if (thingHit.GetComponent<Ball>()) {
            // Debug.Log("Ball entered");
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
