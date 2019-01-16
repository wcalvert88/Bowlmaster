﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreMaster {

    // Returns a list of cumulative scores, like a normal score card
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        foreach(int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // Return a list of individual frame scores, NOT cumulative
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();
        int frameScore;
        // Your code here
        bool tempScoreNeededForSpare = false;
        bool tempScoreNeededForStrike = false;
        int currentTempScoreForSpare = 0;
        int currentTempScoreForStrike = 0;
        int rollsCount = rolls.Count;
        // T03Bowl2345 = {5, 9}  need to find a way to split rolls;
        List<int> subRolls = new List<int>();

        for (int i = 0; i < rolls.Count; i++) {
            subRolls.Add(rolls[i]);
            if (subRolls.Count < 2 && !subRolls.Contains(10)) {
                // T10Spare bonus and T11 moved here
                if (tempScoreNeededForSpare) {
                    frameList.Add(currentTempScoreForSpare + subRolls.First());
                    tempScoreNeededForSpare = false;
                    currentTempScoreForSpare = 0;
                }
                continue;

            // T07Strike returns nothing
            } else if (subRolls.Count < 2 && subRolls.Contains(10)) {
                tempScoreNeededForStrike = true;
                currentTempScoreForStrike = 10;
                subRolls.RemoveAt(0);
                continue;                
            } else if (subRolls.Count == 2) {
                // T02Bowl234 = 5
                frameScore = 0;
                // T01Bowl23 == 5
                foreach(int subRoll in subRolls) {
                    frameScore += subRoll;
                }
                //T12Strike Bonus
                if (tempScoreNeededForStrike) {
                    frameList.Add(currentTempScoreForStrike + frameScore);
                    frameList.Add(frameScore);
                    currentTempScoreForStrike = 0;
                    tempScoreNeededForStrike = false;
                    continue;
                }

                // T08Spare returns nothing
                if (frameScore == 10) {
                    tempScoreNeededForSpare = true;
                    currentTempScoreForSpare = 10;
                } else {
                    frameList.Add(frameScore);
                }
                
                subRolls.RemoveRange(0,2);
            }
        }
        // // T02Bowl234 = 5
        // if (rollsCount % 2 == 0) {
        //     frameScore = 0;
        //     // T01Bowl23 == 5
        //     foreach(int roll in rolls) {
        //         frameScore += roll;
        //     }
        //     frameList.Add(frameScore);
        // } else {
        //     frameScore = 0;
        //     rolls.RemoveAt(rollsCount - 1);
        //     foreach(int roll in rolls) {
        //         frameScore += roll;
        //     }
        //     frameList.Add(frameScore);
        // }
        foreach(int frame in frameList) {
            Debug.Log(frame);
        }
        return frameList;
    }


}
