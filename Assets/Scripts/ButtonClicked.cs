using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour 
{

	//initialization
	public Animator animator;
	public UnityEngine.UI.Button playButton;
	ChangeScene ch = new ChangeScene();

	public void Start()
	{
		playButton.onClick.AddListener (SetBool);
	}

	void SetBool()
	{
		SetBoolWait ();
	}
		
	IEnumerator SetBoolWait()
	{
		yield return new WaitForSeconds (5);
		animator.Play ("playClick");
		ch.changeScene ("Game");
	}
}
