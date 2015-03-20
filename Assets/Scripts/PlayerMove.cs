using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody _rigidBody;
	
	void Update()
	{
		InputMovement();
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
