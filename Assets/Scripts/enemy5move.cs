﻿using UnityEngine;
using System.Collections;

public class enemy5move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("enemy5path"), "time", 20, "easetype", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
