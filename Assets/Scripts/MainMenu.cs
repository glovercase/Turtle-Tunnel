/*
This script holds variables and methods dealing with the main menu and user interactions
with the buttons.
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;

public class MainMenu : MonoBehaviour
{

    //Instance variables
	public Player player = new Player();
    public Text scoreLabel;
    public Text coinLabel;
    private int score;
	public static int [] HighScore = new int[] {0,0,0,0,0,0,0,0,0,0};

    public GameObject backgroundSoundObject;
    public AudioSource backgroundAudioSource;

    public GameObject waterSoundObject;
    public AudioSource waterAudioSource;

    //While awake, has an estimated frame rate of 1000
    private void Awake()
    {
		
        Application.targetFrameRate = 1000;
		coinLabel.text = "Coins: " + Player.coinTotal.ToString();
        backgroundSoundObject = GameObject.Find("BackgroundSong");
        backgroundAudioSource = backgroundSoundObject.GetComponent<AudioSource>();

        waterSoundObject = GameObject.Find("WaterSound");
        waterAudioSource = waterSoundObject.GetComponent<AudioSource>();

		if(PlayerSound.isSoundOn == false)
        {
            backgroundAudioSource.mute = true;
            waterAudioSource.mute = true;
        }
    }

    //When start game is pressed
    public void StartGame(int mode)
    {
        waterAudioSource.Play();
        backgroundAudioSource.Play();
        score = 0;
        player.StartGame(mode);
        gameObject.SetActive(false);
        Cursor.visible = false;
    }

    //Updates the coin score in game as the player collects them
    public void UpdateCoinScore(int value)
    {
        score += value;
    }

	//returns the players score
	public int getScore()
	{
		return score;
	}

    //Shows the distance travelled, and the total coins collected when game has ended.
    public void EndGame(float distanceTraveled)
    {
        backgroundAudioSource.Stop();
        waterAudioSource.Stop();
		Player.coinTotal += score;
        scoreLabel.text = "Total score: " + ((int)(distanceTraveled * 10f)).ToString();
		coinLabel.text = "Coins: " + Player.coinTotal.ToString();
        gameObject.SetActive(true);
        Cursor.visible = true;
		SaveLoad.save ("Score", Player.coinTotal);


		if(((int)(distanceTraveled * 10f))>HighScore[1]){
			HighScore [1] = (int)(distanceTraveled * 10f);
			Array.Sort (HighScore);
			PlayerPrefs.SetInt ("HS1", HighScore[0]);
			PlayerPrefs.SetInt ("HS2", HighScore[1]);
			PlayerPrefs.SetInt ("HS3", HighScore[2]);
			PlayerPrefs.SetInt ("HS4", HighScore[3]);
			PlayerPrefs.SetInt ("HS5", HighScore[4]);
			PlayerPrefs.SetInt ("HS6", HighScore[5]);
			PlayerPrefs.SetInt ("HS7", HighScore[6]);
			PlayerPrefs.SetInt ("HS8", HighScore[7]);
			PlayerPrefs.SetInt ("HS9", HighScore[8]);
			PlayerPrefs.SetInt ("HS10", HighScore[9]);
		}

	}
}