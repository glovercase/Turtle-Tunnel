using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * the player sound script
 * sound can be on or off 
 * using the toggle button
 */ 

public class PlayerSound : MonoBehaviour 
{

    public Toggle myToggle;
    public static bool isSoundOn; 

	//initialise on setup
	void Awake()
	{
		DontDestroyOnLoad (myToggle);
	}

	//	//initialise on start
    public void start()
    {
        isSoundOn = myToggle.isOn;

    }

	//Updates every frame
	void Update()
	{
		toggleSound ();
		previousState ();
		//PlayerPrefs.GetInt ("SoundOn");	
	}

	//Sound on functionality
    public void toggleSound()
    {
			
		if(myToggle.isOn)
        {
			PlayerPrefs.SetInt ("SoundOn", 1);
            isSoundOn = true;
            print("Sound is on");
        }
        else
        {
			PlayerPrefs.SetInt ("SoundOn", 0);
            isSoundOn = false;
            print("Sound is off");
        }
    }

	//load the previous state of the sound on or off
	void  previousState()
	{
		if (PlayerPrefs.GetInt ("SoundOn").Equals (1)) 
		{
			myToggle.isOn = true;
		} 
		else 
		{
			myToggle.isOn = false;
		}
	}
}
