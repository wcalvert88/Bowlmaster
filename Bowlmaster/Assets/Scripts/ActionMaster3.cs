﻿// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ActionMaster3
// {
//     public enum Action {Tidy, Reset, EndTurn, EndGame};

//     private int[] bowls = new int[21];
//     private int bowl = 1;

//     public static Action NextAction(List<int>pinFalls) {
//         ActionMaster am = new ActionMaster();
//         Action currentAction = new Action();

//         foreach(int pinFall in pinFalls) {
//             currentAction = am.Bowl(pinFall);
//         }
//         return currentAction;
//     }

//     private Action Bowl(int pins) { // TODO make private after changing PinSetter

//         if (pins < 0 || pins > 10) {
//             throw new UnityException("Invalid number of pins!");
//         }

//         bowls[bowl - 1] = pins;


//         Debug.Log(bowl);
//         if (bowl == 21) {
//             return Action.EndGame;
//         }

//         // Handle last frame special cases
//         if (bowl >= 19 && pins == 10) {
//             bowl++;
//             return Action.Reset;
//         } else if (bowl == 20) {
//             int totalPins = bowls[19 - 1] + bowls[20 - 1];
//             bowl++;
//             if (bowls[19-1] == 10 && bowls[20-1] == 0) {
//                 return Action.Tidy;
//             } else if (totalPins == 10) {
//                 return Action.Reset;
//             } else if (Bowl21Awarded()) {
//                 return Action.Tidy;
//             } else {
//                 return Action.EndGame;
//             }
//         }
        
//         // T02
//         // If first bowl of frame return Action.Tidy
//         if (bowl % 2 != 0) { // First bowl of frame
//             if (pins == 10) {
//                 bowl += 2;
//                 return Action.EndTurn;
//             } else {
//                 bowl += 1;
//                 return Action.Tidy;
//             }
//         // T03
//         } else if (bowl % 2 == 0) { // Second bowl of frame
//             bowl += 1;
//             return Action.EndTurn;
//         }
        

//         throw new UnityException("Not sure what action to return!");
//     }

//     private bool Bowl21Awarded() {
//         // Remember that arrays start counting at 0
//         return (bowls[19-1] + bowls[20 -1] >= 10);
//     }
// }
