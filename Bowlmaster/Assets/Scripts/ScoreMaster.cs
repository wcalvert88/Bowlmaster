using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int rollsCount = rolls.Count;
        // T03Bowl2345 = {5, 9}  need to find a way to split rolls;
        List<int> subRolls = new List<int>();

        for (int i = 0; i < rolls.Count; i++) {
            subRolls.Add(rolls[i]);
            if (subRolls.Count < 2) {
                continue;
            } else if (subRolls.Count >= 2) {
                // T02Bowl234 = 5
                // if (rollsCount % 2 == 0) {
                    frameScore = 0;
                    // T01Bowl23 == 5
                    foreach(int subRoll in subRolls) {
                        frameScore += subRoll;
                    }
                    frameList.Add(frameScore);
                // } else {
                //     frameScore = 0;
                //     rolls.RemoveAt(rollsCount - 1);
                //     foreach(int roll in rolls) {
                //         frameScore += roll;
                //     }
                //     frameList.Add(frameScore);
                // }

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
