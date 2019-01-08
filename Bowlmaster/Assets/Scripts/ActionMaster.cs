﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action {Tidy, Reset, EndTurn, EndGame};

    // private int[] bowls = new int[21];
    private int bowl = 1;

    public Action Bowl(int pins) {

        if (pins < 0 || pins > 10) {
            throw new UnityException("Invalid number of pins!");
        }

        // Other behaviour here, e.g. last frame
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
}
