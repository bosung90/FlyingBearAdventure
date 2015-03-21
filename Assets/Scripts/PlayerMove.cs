using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	[Range(0,10f)]
	public float speed = 10f;

	public Transform cardboardCamera;

	private Rigidbody _rigidBody;
	private NetworkView _networkView;

	private Cardboard cardboard;

	//===========Make Transform Sync smooth on client side using interpolation + prediction=====================
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = _rigidBody.position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = _rigidBody.velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = _rigidBody.position;
		}
	}
	private void SyncedMovement()
	{
		if(Vector3.Distance(syncStartPosition, syncEndPosition) > 2f)
		{
			syncStartPosition = syncEndPosition;
			_rigidBody.position = syncEndPosition;
			syncTime = 0f;
		}
		else
		{
			syncTime += Time.deltaTime;
			_rigidBody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
		}
	}
	//=================================================================================

	
	void Update()
	{
//		if (_networkView.isMine) 
//		{
			InputMovement ();
//		}
//		else
//		{
//			SyncedMovement();
//		}
	}
	
	void InputMovement()
	{
		if (cardboard.CardboardTriggered)
			_rigidBody.MovePosition(_rigidBody.position + cardboardCamera.forward * speed * Time.deltaTime);
		
//		if (Input.GetKey(KeyCode.S))
//			_rigidBody.MovePosition(_rigidBody.position - Vector3.forward * speed * Time.deltaTime);
//		
//		if (Input.GetKey(KeyCode.D))
//			_rigidBody.MovePosition(_rigidBody.position + Vector3.right * speed * Time.deltaTime);
//		
//		if (Input.GetKey(KeyCode.A))
//			_rigidBody.MovePosition(_rigidBody.position - Vector3.right * speed * Time.deltaTime);
	}

	// Use this for initialization
	void Start () {
		_networkView = GetComponent<NetworkView> ();
		_rigidBody = GetComponent<Rigidbody> ();

		cardboard = new Cardboard ();
	}
}
