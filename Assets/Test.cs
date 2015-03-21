using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("enemy4path"), "time", 10, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
