using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

	Text objectives;
	string firstObj, secondObj, thirdObj, fourthObj, fifthObj;

	// Use this for initialization
	void Start () {
		objectives = GetComponent<Text> ();
		firstObj = ">> (1) Find the document to hack into system [ ] \n\n\n";
		secondObj = ">> (2) Find a Computer to breach the security [ ] \n\n\n";
		thirdObj = ">> (3) Find explosives [ ] \n\n\n";
		fourthObj = ">> (4) Plant Bombs on the mark [ ] \n\n\n";
		fifthObj = ">> (5) Excape the factory [ ] \n";


	}
	
	// Update is called once per frame
	void Update () {
		objectives.text =
			":: Missions :: \n" +
				"================= \n\n" + firstObj + secondObj + thirdObj + fourthObj + fifthObj;

		checkQuest ();
	}

	void checkQuest() {
		if (Quest.currentQ == Quest.questType.Quest2) {
			firstObj = ">> (1) Find the document to hack into system [x] \n";
		} else if (Quest.currentQ == Quest.questType.Quest3) {
			secondObj = ">> (2) Find a Computer to breach the security [x] \n";
		} else if (Quest.currentQ == Quest.questType.Quest4) {
			thirdObj = ">> (3) Find explosives [x] \n";
		} else if (Quest.currentQ == Quest.questType.Finish) {
			fourthObj = ">> (4) Plant Bombs on the mark [x] \n";
			fifthObj = ">> (5) Excape the factory [x] \n";
		}
	}
}
