using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class TurtleTunnelUnitTests {

    //Tests
    GameTest gmt = new GameTest ();

    public bool doesExist = true;

    //CoinBehaviour
    [Test]
    public void T01PlayerHitsObstacle(){
        Collider collider = new Collider();
        if((collider.gameObject.CompareTag ("Small Obstacle"))){
            Assert.IsTrue (doesExist);
        } else {
            Assert.IsFalse (doesExist);
        }
    }

    [Test]
    public void T02PlayerCollectsCoin(){
        Collider collider = new Collider ();
        if ((collider.gameObject.CompareTag ("Coin"))) {
            Assert.IsTrue (doesExist);
        } else {
            Assert.IsFalse (doesExist);
        }
    }

    [Test]
    public void T03TurtleExisits(){
        bool exists = true;
        if (GameObject.Find ("Turtle")) {
            Assert.IsTrue (exists);
        } else {
            Assert.IsFalse (exists);
        }
    }

    [Test]
    public void T04PipeExisits(){
        bool exists = true;
        if (GameObject.Find ("Pipe System")) {
            Assert.IsTrue (exists);
        } else {
            Assert.IsFalse (exists);
        }
    }

	//gmt.menu.player.pipeSystem.pipePrefab != null
    [Test] 
    public void T05ObstacleExists(){
        bool exists = true;
		
		if (GameObject.Find ("Small Obstacle")) {
            Assert.IsTrue (exists);
        } else {
            Assert.IsFalse (exists);
        }
    }

    [Test]
    public void T06CoinRotates(){
        Assert.AreEqual (gmt.cb.rotateSpeed, 50f);
    }


    [Test]
    public void T07GameGetsFaster(){
        Assert.IsTrue(gmt.speedIncreased());
    } 

    [Test]
    public void T08GameStarts(){
        Assert.IsTrue(gmt.gameState());
    }

    [Test]
    public void T09GameEnds(){
        Assert.IsFalse(gmt.gameState());
    }

    // Sprint 2 Unit Tests

 

  
}

