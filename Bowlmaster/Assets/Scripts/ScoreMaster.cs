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
        int frameScore = 0;
        // Your code here
        


        // T02Bowl234 = 5
        if (rolls.Count % 2 == 0) {

            // T01Bowl23 == 5
            foreach(int roll in rolls) {
                frameScore += roll;
            }
        } else {
            rolls.RemoveAt(rolls.Count - 1);
            foreach(int roll in rolls) {
                frameScore += roll;
            }
        }
        frameList.Add(frameScore);
        return frameList;
    }


}
