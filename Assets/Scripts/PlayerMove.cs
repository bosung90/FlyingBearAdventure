using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody _rigidBody;

	private NetworkView _networkView;
	
	void Update()
	{
		if (_networkView.isMine) 
		{
			InputMovement ();
		}
		_rigidBody = GetComponent<Rigidbody> ();

	}
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			_rigidBody.MovePosition(_rigidBody.position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			_rigidBody.MovePosition(_rigidBody.position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			_rigidBody.MovePosition(_rigidBody.position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			_rigidBody.MovePosition(_rigidBody.position - Vector3.right * speed * Time.deltaTime);
	}

	// Use this for initialization
	void Start () {
		_networkView = GetComponent<NetworkView> ();
	}
}
