using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ScoreMaster {

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

    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frames = new List<int>();

        // Index i points to 2nd bowl of frame.
        for (int i = 1; i < rolls.Count; i += 2) {
            if (frames.Count == 10) { // prevents going onto an 11th frame
                break;
            }
            if (rolls[i - 1] + rolls[i] < 10) { // Normal "open" frame
                frames.Add(rolls[i - 1] + rolls[i]);
            }
            if (rolls.Count - i <= 1) { // Insufficient look ahead
                break;
            }

            if (rolls[i -1] == 10) { // Strike
                i--;    // Strike frame just has 1 bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            } else if (rolls[i - 1] + rolls[i] == 10) { // Calculate Spare bonus
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }

    // Return a list of individual frame scores, NOT cumulative
    // public static List<int> ScoreFrames(List<int> rolls) {
    //     List<int> frameList = new List<int>();
    //     int frameScore;
    //     // Your code here
    //     bool tempScoreNeededForSpare = false;
    //     bool tempScoreNeededForStrike = false;
    //     int currentTempScoreForSpare = 0;
    //     List<int> currentTempScoreForStrike = new List<int>();
    //     int rollsCount = rolls.Count;
    //     // T03Bowl2345 = {5, 9}  need to find a way to split rolls;
    //     List<int> subRolls = new List<int>();

    //     for (int i = 0; i < rolls.Count; i++) {
    //         subRolls.Add(rolls[i]);
    //         // Debug.Log("Current roll" + rolls[i] + " subRolls count " + subRolls.Count);
    //         if (subRolls.Count < 2 && !subRolls.Contains(10)) {
    //             // T10Spare bonus and T11 moved here
    //             if (tempScoreNeededForSpare) {
    //                 frameList.Add(currentTempScoreForSpare + subRolls.First());
                            
    //                 tempScoreNeededForSpare = false;
    //                 currentTempScoreForSpare = 0;
    //             }
    //             // Debug.Log("continue hit T10");
    //             continue;

    //         // T07Strike returns nothing
    //         } else if (subRolls.Count < 2 && subRolls.Contains(10)) {
    //             tempScoreNeededForStrike = true;
    //             currentTempScoreForStrike.Add(10);
    //             subRolls.RemoveAt(0);
    //             // Debug.Log("continue hit T07");
    //             continue;
    //         //} else if (subRolls.Count < 2 && !subRolls.Contains(10) && currentTempScoreForStrike[1] == 10) {
    //             //Debug.Log("Possible multi strike");
    //         } else if (subRolls.Count == 2) {
    //             // T02Bowl234 = 5
    //             frameScore = 0;
    //             // T01Bowl23 == 5
    //             foreach(int subRoll in subRolls) {
    //                 frameScore += subRoll;
    //             }
    //             // Debug.Log("FrameScore" + frameScore);
    //             //T12Strike Bonus
    //             if (tempScoreNeededForStrike) {
    //                 frameList.Add(currentTempScoreForStrike.Sum() + frameScore);
    //                 // PrintFrames(frameList);
    //                 frameList.Add(frameScore);
    //                 // PrintFrames(frameList);
    //                 currentTempScoreForStrike.RemoveRange(0,currentTempScoreForStrike.Count() - 1);
    //                 tempScoreNeededForStrike = false;
    //                 // Debug.Log("continue hit T12");

    //                 // T13 Strike Bonus
    //                 subRolls.RemoveRange(0,2);
    //                 continue;
    //             }

    //             // T08Spare returns nothing
    //             if (frameScore == 10) {
    //                 tempScoreNeededForSpare = true;
    //                 currentTempScoreForSpare = 10;
    //             } else {
    //                 frameList.Add(frameScore);
    //                 // PrintFrames(frameList);
    //             }
                
    //             subRolls.RemoveRange(0,2);
    //         }
    //     }

    //     PrintFrames(frameList);
    //     return frameList;
    // }

    // public static void PrintFrames(List<int> frameList) {
    //     foreach(int frame in frameList) {
    //         Debug.Log(frame);
    //     }
    // }

}
