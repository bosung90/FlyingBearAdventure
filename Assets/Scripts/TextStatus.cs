using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextStatus : MonoBehaviour {

	Text msg;

	// Use this for initialization
	void Start () {

		msg = GetComponent<Text> ();
		msg.text = "";
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Quest.currentQ == Quest.questType.Finish) {
			msg.text = "Mission Accomplished";
		} else if (Quest.currentQ == Quest.questType.GameOver) {
			msg.text = "YOU DIED, GAME OVER";
		}

	
	}
}
