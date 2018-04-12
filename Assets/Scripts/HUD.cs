/*
This script holds variables and methods used for the HUD interactions in game.
*/

using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{

    //instance variables
    public Text distanceLabel, velocityLabel;

	public GameObject resumeCanvas,settingsCanvas;
	public MainMenu mainMenu;

    //Sets the in game text labels for the distance traveled, and the current velocity.
    public void SetValues (float distanceTraveled, float velocity)
	{
		distanceLabel.text = "Score: " + ((int)(distanceTraveled * 10f)).ToString();
		velocityLabel.text = "Coins: " + mainMenu.getScore().ToString();
	}

	public void PausePressed()
	{
		Time.timeScale = 0;
		resumeCanvas.gameObject.SetActive (true);
	}

	public void ResumePressed()
	{
		Time.timeScale = 1;
		resumeCanvas.gameObject.SetActive (false);	
	}

	public void ChangeToMainMenu()
	{
		Time.timeScale = 1;
		ChangeScene ch = new ChangeScene ();
		ch.changeScene ("Start Menu");
	}

	public void ChangetoSettings()
	{
		settingsCanvas.gameObject.SetActive (true);
		resumeCanvas.gameObject.SetActive (false);
	}

	public void ChangeToResume()
	{
		settingsCanvas.gameObject.SetActive (false);
		resumeCanvas.gameObject.SetActive (true);
	}
}