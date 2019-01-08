using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl(int pins) {

        if (pins < 0 || pins > 10) {
            throw new UnityException("Invalid number of pins!");
        }

        bowls[bowl - 1] = pins;

        // Other behaviour here, e.g. last frame
        // bowl is in last frame
        // Debug.Log(bowl);
        // // T04
        // if (bowl >= 19 && bowl < 21) {
        //     if (pins == 10) {
        //         bowl += 1;
        //         return Action.Reset;   
        //     }
        // // T05
        // } else if (bowl >= 21) {
        //     return Action.EndGame;
        // } else if (bowl == 20) {
        //     if (pins != 10) {
        //         return Action.EndGame;
        //     }
        // }
        if (bowl == 21) {
            return Action.EndGame;
        }

        // Handle last frame special cases
        // T05
        if (bowl >= 19 && Bowl21Awarded()) {
            bowl += 1;
            return Action.Reset;
        // T07
        } else if (bowl == 20 && !Bowl21Awarded()) {
            return Action.EndGame;
        }

        // T01
        if (pins == 10) {
            bowl += 2;
            return Action.EndTurn;
        }

        // T02
        // If first bowl of frame return Action.Tidy
        if (bowl % 2 != 0) { // Mid frame (or last frame)
            if (pins > 0  && pins < 10) {
                bowl += 1;
                return Action.Tidy;
            }
        // T03
        } else if (bowl % 2 == 0) {
            // End of frame
            bowl += 1;
            return Action.EndTurn;
        }
        

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded() {
        // Remember that arrays start counting at 0
        return (bowls[19-1] + bowls[20 -1] >= 10);
    }
}
