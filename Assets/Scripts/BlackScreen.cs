using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour {

	Image screen;

	// Use this for initialization
	void Start () {

		screen = GetComponent<Image> ();
		screen.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Quest.currentQ == Quest.questType.Finish || Quest.currentQ == Quest.questType.GameOver) {
			screen.enabled = true;
		}
	
	}
}
