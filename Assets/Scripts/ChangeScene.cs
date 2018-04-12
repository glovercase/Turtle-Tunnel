/*
This script holds a method for changing the screen/game state.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	//Animator objects for the buttons
	public Animator playbuttonAnimator, highscoreAnimator, settingsAnimator, instructionsAnimator, titleAnimator;
	
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	//set of animations to play while exiting out of main menu
	void ExitAnimation()
	{
		playbuttonAnimator.Play ("playClick");
		instructionsAnimator.Play ("instructionsClick");
		highscoreAnimator.Play ("highscoreClick");
		settingsAnimator.Play ("settingsClick");
		titleAnimator.Play ("ttunnelText");
	}

	public void playButtonPressed()
	{
		ExitAnimation ();
		StartCoroutine(WaitForPlay ());
	}

	public void highScorePressed()
	{
		ExitAnimation ();
		StartCoroutine(WaitForHighScore ());
	}

	public void settingsPressed()
	{
		ExitAnimation ();
		StartCoroutine(WaitForSettings ());
	}

	public void instructionsPressed()
	{
		ExitAnimation ();
		StartCoroutine(WaitForInstructions ());
	}

	IEnumerator WaitForPlay()
	{
		yield return new WaitForSeconds (01f);
		SceneManager.LoadScene ("Game");
	}

	IEnumerator WaitForHighScore()
	{
		yield return new WaitForSeconds (01f);
		SceneManager.LoadScene ("HighScore");
	}

	IEnumerator WaitForInstructions()
	{
		yield return new WaitForSeconds (01f);
		SceneManager.LoadScene ("Instructions");
	}

	IEnumerator WaitForSettings()
	{
		yield return new WaitForSeconds (01f);
		SceneManager.LoadScene ("SettingsMenu");
	}


}