using UnityEngine;
using System.Collections;

public class CharControllerMove : MonoBehaviour {

	public float speed = 1.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Transform cardboardCamera;

	private NetworkView _networkView;
	
	private bool isWalking = false;

	private Vector3 moveDirection = Vector3.zero;

	CharacterController controller;

	Animation charAnimation;

	void Start()
	{
		_networkView = GetComponent<NetworkView> ();
		controller = GetComponent<CharacterController>();

		CardboardMagnetSensor.SetEnabled(true);
		// Disable screen dimming:
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera") as GameObject;
		if(cam != null)
		{
			cardboardCamera = cam.transform;
		}

		charAnimation = GetComponent<Animation> ();
	}

	void Update() 
	{
		if (_networkView.isMine) 
		{
			InputMovement ();
		}
	}

	void InputMovement()
	{
		if(CardboardMagnetSensor.CheckIfWasClicked ())
		{
			isWalking = !isWalking;
			CardboardMagnetSensor.ResetClick();
		}
		
		if (isWalking) {
			moveDirection = cardboardCamera.forward;
			moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
			moveDirection = moveDirection.normalized;
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			controller.Move(moveDirection * Time.deltaTime);
			charAnimation.Play ("walk");
		}
		else if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
		{
			CharacterController controller = GetComponent<CharacterController>();
			if (controller.isGrounded) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;
				
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
			charAnimation.Play ("walk");
		}
		else
		{
			charAnimation.Play ("idle");
		}
	}
}
