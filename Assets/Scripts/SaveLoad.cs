
using UnityEngine;
using System.Collections;

/**
 * saves and loads the players scores 
 * using PlayerPrefs, built in functionality of unity
 */ 

public class SaveLoad : MonoBehaviour
{

	public static void save(string pref, int number) 
	{
		PlayerPrefs.SetInt(pref, number);
	}
	public static int load(string pref) 
	{
		return PlayerPrefs.GetInt(pref);
	}
}
