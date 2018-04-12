/*
This method holds instance variables and methods used by the player character in game
It deals with collision, distance travelled, velocity and position in the pipe.
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{

    //Instance variables
	public PipeSystem pipeSystem;

	public float startVelocity;
	public float rotationVelocity;

	public MainMenu mainMenu;
	public HUD hud;

	public float[] accelerations;

	private Pipe currentPipe;

	public float acceleration, velocity;
	private float distanceTraveled;
	private float deltaToRotation;
	private float systemRotation;
	private float worldRotation;
	public float avatarRotation;
    public Avatar avatar;
	public static int coinTotal;
	public bool isAccel = false;

    private Vector2 touchOrigin = -Vector2.one;

	private Transform world, rotater;

    //This method initialises the player and game values when a new game is started
    public void StartGame (int accelerationMode) 
	{
		distanceTraveled = 0f;
		avatarRotation = 0f;
		systemRotation = 0f;
		worldRotation = 0f;
		acceleration = accelerations[accelerationMode];
		velocity = startVelocity;
		currentPipe = pipeSystem.SetupFirstPipe();
		SetupCurrentPipe();
		gameObject.SetActive(true);
		hud.SetValues(distanceTraveled, velocity);
	}

    //Sets the player as inactive when the game has ended. It also switches the screen to the end screen
	public void Die () 
	{
		mainMenu.EndGame(distanceTraveled);
		gameObject.SetActive(false);
	}

	//initialise on setup
	private void Awake () 
	{
		world = pipeSystem.transform.parent;
		rotater = transform.GetChild(0);
		gameObject.SetActive(false);
	}

    //updates the player every frame
	private void Update () 
	{
		velocity += acceleration * Time.deltaTime;
		float delta = velocity * Time.deltaTime;
		distanceTraveled += delta;
		systemRotation += delta * deltaToRotation;

		if (systemRotation >= currentPipe.CurveAngle) 
		{
			delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
			currentPipe = pipeSystem.SetupNextPipe();
			SetupCurrentPipe();
			systemRotation = delta * deltaToRotation;
		}

		pipeSystem.transform.localRotation =
			Quaternion.Euler(0f, 0f, systemRotation);

		//The value of isAccel is set to false as default which the game initializes the control as touch input.
		//The button click in settings menu is able to change this value to false or true, depending on the button
		//pressed. If the accelrometer button was pressed it calls UpdateAvatarRotationAccel(), other wise it calls
		//UpdateAvatarRotationTouch(), two methods which determine the controls for the game.

		if (isAccel == false) {
			UpdateAvatarRotationTouch ();
		} else {
			UpdateAvatarRotationAccel ();
		}

        hud.SetValues(distanceTraveled, velocity);
	}


	//This method deals with moving the player sideways in the pipe (left or right). It also holds functionality for letting the player jump.
	public void UpdateAvatarRotationTouch()
	{
		float rotationInput = 0f;
		isAccel = false;
		if (Application.isMobilePlatform) // If on mobile
		{
			if (Input.touchCount == 1)
			{
				if (Input.GetTouch(0).position.x < Screen.width * 0.5f)
				{
					rotationInput = -1f; // Move left if touched on left half of screen
				}
				else if (Input.GetTouch(0).position.x > Screen.width * 0.6f)
				{
					rotationInput = 1f; // else move right
				}
				else
				{
					avatar.Jump();
				}
			}
		}

		//if jumping
		else if (Input.GetKeyDown(KeyCode.UpArrow)){
			avatar.Jump();
		}
		else
		{
			rotationInput = Input.GetAxis("Horizontal");
		}
		avatarRotation += rotationVelocity * Time.deltaTime * rotationInput;
		if (avatarRotation < 0f)
		{
			avatarRotation += 360f;
		}
		else if (avatarRotation >= 360f)
		{
			avatarRotation -= 360f;
		}

		rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
	}


	public void UpdateAvatarRotationAccel()
	{

		var temp = Input.acceleration.x;
		float rotationInput = 0f;
		isAccel = true;

		if (temp > 0 && temp < 0.15) {
			rotationInput = 0f;
		} else if (temp < 0 && temp > -0.15) {
			rotationInput = 0f;
		} else if (temp > 0.15) {
			rotationInput = 1f;
		} else if (temp < -0.15) {
			rotationInput = -1f;
		}

		if (Input.touchCount == 1) 
		{
			avatar.Jump ();
		}

		avatarRotation += rotationVelocity * Time.deltaTime * rotationInput;
		if (avatarRotation < 0f)
		{
			avatarRotation += 360f;
		}
		else if (avatarRotation >= 360f)
		{
			avatarRotation -= 360f;
		}

		rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
	}



    //Sets the current pipe relative to the previous pipe so its a transition.
    private void SetupCurrentPipe ()
	{
		deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
		worldRotation += currentPipe.RelativeRotation;
		if (worldRotation < 0f) 
		{
			worldRotation += 360f;
		}
		else if (worldRotation >= 360f)
		{
			worldRotation -= 360f;
		}
		world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
	}
}