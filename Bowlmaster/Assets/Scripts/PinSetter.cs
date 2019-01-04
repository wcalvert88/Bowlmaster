using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    [SerializeField] public Text standingDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(CountStanding());
        standingDisplay.text = CountStanding().ToString();
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
