using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextStatus : MonoBehaviour {

	Text msg;

	// Use this for initialization
	void Start () {

			msg = GetComponent<Text> ();
		msg.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {



		if (Quest.currentQ == Quest.questType.Finish) {
			msg.enabled = true;
			msg.text = "Mission Accomplished";
		} else if (Quest.currentQ == Quest.questType.GameOver) {
			msg.enabled = true;
			msg.text = "YOU DIED, GAME OVER";
		}

	
	}
}
