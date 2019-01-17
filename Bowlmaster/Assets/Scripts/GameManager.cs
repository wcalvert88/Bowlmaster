using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall) {
        try {
            bowls.Add(pinFall);
            ball.Reset();
            pinSetter.PerformAction(ActionMaster.NextAction(bowls));
        } catch {
            Debug.LogWarning("Something went wrong in GameManager.Bowl()");
        }

        try {
            scoreDisplay.FillRollCard(bowls);
        } catch {
            Debug.LogWarning("Unable to update scores. Something went wrong in ScoreDisplay.FillRollCard");
        }
        
    }
}
