﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    public GameObject pinSet;
    private Animator animator;
    private PinCounter pinCounter;

    // ActionMaster actionMaster = new ActionMaster();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void PerformAction (ActionMaster.Action action) {
        if(action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject thingHit = other.gameObject;
        
        if (thingHit.GetComponent<Ball>()) {

        }
    }
}
