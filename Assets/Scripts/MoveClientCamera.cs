using UnityEngine;
using System.Collections;

public class MoveClientCamera : MonoBehaviour {

	private Transform playerTransform;
	private Transform orignalPos;

	// Use this for initialization
	void Start () {
		orignalPos = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(playerTransform == null)
		{
			GameObject p = GameObject.FindGameObjectWithTag("Player");
			if(p!=null)
				playerTransform = p.transform;
		}
		if(playerTransform != null)
		{
			if(playerTransform.position.z <-10)
			{
				this.transform.position = new Vector3(orignalPos.position.x, orignalPos.position.y, -10);
			}
			else if(playerTransform.position.z > 11)
			{
				this.transform.position = new Vector3(orignalPos.position.x, orignalPos.position.y, 11);
			}
			else
			{
				this.transform.position = new Vector3(orignalPos.position.x, orignalPos.position.y, playerTransform.position.z);
			}
		}

	}
}
