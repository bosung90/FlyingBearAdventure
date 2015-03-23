using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private bool canSee = false;

	public Transform Sight;
	private Transform Target = null;
	[Range(0,30f)]
	public float VisionRange = 10.0f;
	[Range(0,360f)]
	public float VisionAngle = 50.0f;

	private Renderer ren;

	private Vector3 prev_coord = Vector3.zero;

	// Use this for initialization
	void Start () {
		ren = GetComponentInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (prev_coord != Vector3.zero) 
		{
			Vector3 dir = (this.transform.position - prev_coord).normalized;
			this.transform.forward = dir;
		}
		prev_coord = this.transform.position;

		if(Target == null)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player") as GameObject;
			if(player == null)
			{
				return;
			}
			else
			{
				Target = player.transform;
			}
		}
	
		//calculate the angle between this and target
		Vector2 targetDir = new Vector2(Target.position.x - transform.position.x, Target.position.z - transform.position.z);
		Vector2 forward = new Vector2(transform.forward.x, transform.forward.z);
        float angle = Vector2.Angle(targetDir, forward);

		if(angle <= VisionAngle/2f)
		{
			RaycastHit hit;
			if(Physics.Raycast(Sight.transform.position, Sight.transform.forward, out hit, VisionRange))
			{
				if(hit.transform.tag == "Player")
				{
					canSee = true;
				}
				else
				{
					canSee = false;
				}
			}
			else
			{
				canSee = false;
			}
		}
		else
		{
			canSee = false;
		}

		if(canSee)
		{
			ren.material.color = Color.red;
		}
		else
		{
			ren.material.color = Color.green;
		}
	}
}
