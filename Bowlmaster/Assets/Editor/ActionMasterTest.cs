using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest : MonoBehaviour
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup() {
        actionMaster = new ActionMaster();
    }
    

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl28SpareReturnsEndTurn() {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }

    // [Test]
    // public void T04LastFrameAllowExtraShotIfStrikeOrSpare() {
    //     for(int i = 0; i < 9; i++) {
    //         Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    //     }
    //     Assert.AreEqual(reset, actionMaster.Bowl(10));
    //     Assert.AreEqual(reset, actionMaster.Bowl(10));
    // }

    // [Test]
    // public void T05LastShotOfLastFrameEndsGame() {
    //     for(int i = 0; i < 9; i++) {
    //         Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    //     }
    //     Assert.AreEqual(reset, actionMaster.Bowl(10));
    //     Assert.AreEqual(reset, actionMaster.Bowl(10));
    //     Assert.AreEqual(endGame, actionMaster.Bowl(10));
    // }

    // [Test]
    // public void T06LastFrame2ShotsIfNotStrikeOrSpare() {
    //     for(int i = 0; i < 9; i++) {
    //         Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    //     }
    //     Assert.AreEqual(reset, actionMaster.Bowl(10));
    //     Assert.AreEqual(endGame, actionMaster.Bowl(9));
    // }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame() {
        int[] rolls = {1,1, 1,1, 1,1, 1,1,1,1, 1,1, 1,1, 1,1, 1,1 };
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T06CheckResetAtSpareInLastFrame() {
        int[] rolls = {1,1, 1,1, 1,1, 1,1,1,1, 1,1, 1,1, 1,1, 1,1 };
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(reset, actionMaster.Bowl(9));
    }

    [Test]
    public void T07YouTubeRollsEndInEndGame() {
        int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }

    [Test]
    public void T08GameEndsAtBowl20() {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(1));
    }

    [Test]
    public void T09TidyIfNotStrikeInBowl19And20() {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }

    [Test]
    public void T10TidyIfNotStrikeInBowl19And20() {
        int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }

    [Test]
    public void T11BowlIndexTest() {
        int[] rolls = {0, 10, 5};
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }

    [Test]	
    public void	T12Turkey10thFrame() {	
        int[] rolls	= {1,1,	1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};	
        foreach(int roll in rolls) {
            actionMaster.Bowl(roll);	
        }	
        Assert.AreEqual(reset, actionMaster.Bowl(10));	
        Assert.AreEqual(reset, actionMaster.Bowl(10));	
        Assert.AreEqual(endGame, actionMaster.Bowl(10));	
    }
}
