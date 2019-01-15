﻿// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using System.Linq;
// [TestFixture]
// public class ActionMasterTest : MonoBehaviour
// {
//     private List<int> pinFalls;
//     private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
//     private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//     private ActionMaster.Action reset = ActionMaster.Action.Reset;
//     private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

//     [SetUp]
//     public void Setup() {
//         pinFalls = new List<int>();
//     }
    

// 	[Test]
// 	public void T00PassingTest() {
// 		Assert.AreEqual (1, 1);
// 	}

//     [Test]
//     public void T01OneStrikeReturnsEndTurn() {
//         pinFalls.Add(10);
//         Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
//     }

//     [Test]
//     public void T02Bowl8ReturnsTidy() {
//         pinFalls.Add(8);
//         Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
//     }

//     [Test]
//     public void T03Bowl28SpareReturnsEndTurn() {
//         int[] rolls = {8,2};
//         Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T05CheckResetAtStrikeInLastFrame() {
//         int[] rolls = {1,1, 1,1, 1,1, 1,1,1,1, 1,1, 1,1, 1,1, 1,1, 10};
// Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T06CheckResetAtSpareInLastFrame() {
//         int[] rolls = {1,1, 1,1, 1,1, 1,1,1,1, 1,1, 1,1, 1,1, 1,1, 1,9 };
//         Assert.AreEqual(reset,  ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T07YouTubeRollsEndInEndGame() {
//         int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2, 9};

//         Assert.AreEqual(endGame,  ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T08GameEndsAtBowl20() {
//         int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 1};
//         Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T09TidyIfNotStrikeInBowl19And20() {
//         int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 5};
//         Assert.AreEqual(tidy,  ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T10TidyIfNotStrikeInBowl19And20() {
//         int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0};
//         Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]
//     public void T11BowlIndexTest() {
//         int[] rolls = {0, 10, 5, 1};

//         Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//     }

//     [Test]	
//     public void	T12Turkey10thFrame() {	
//         int[] rolls	= {1,1,	1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 10, 10};		
//         Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));	
//     }

//     [Test]
//     public void	T13ZeroOneGivesEndTurn() {	
//         int[] rolls = {0, 1};
//         Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));	
//     }
// }
