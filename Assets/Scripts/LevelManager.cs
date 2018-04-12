/*
This script consists of variables and methods used in managing the game state/level.
It has code which may be used in a later iteration of the game.  
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

    //Instance variable
	public float autoLoadNextLevelAfter;

    //This method starts the level manager in game
    void Start ()
	{
		if(autoLoadNextLevelAfter == 0)
		{
			Debug.Log ("Level auto load disabled");
		}
		else
		{
	 		Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
	 	}
	}

    //This method loads the current level
    public void LoadLevel(string name)
	{
		Debug.Log ("New Level load: " + name);

		//Application.LoadLevel (name);
        SceneManager.LoadScene(name);
    }

    //This method handles if the user wants to quit
    public void QuitRequest()
	{
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    //This method loads the next level. Currently not in use and unimplemented
    public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
