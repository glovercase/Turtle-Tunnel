/*
This script holds a method used to show a coin spinning. It differs from the coinBehaviour script
as this script is used in the main menu, not in game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpin : MonoBehaviour
{

	
	// Update is called once per frame
	void Update () 
	{
        transform.Rotate(0, 5, 0, Space.World);		
	}
}
