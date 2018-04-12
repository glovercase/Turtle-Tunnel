/*
This script holds variables and a method for describing the behaviour of a coin in game.
*/

using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public int coinPoints = 1; // points awarded per coin
    public float rotateSpeed = 50f; // speed the coins rotate at

    // This method rotates the coins in game
    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
    }
}
