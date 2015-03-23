using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {
	private AudioSource[] audios;
	private AudioSource bgm, _fin, _gg;
	bool isFinishSoundPlayed = false;
	bool isGameOverSoundPlayed = false;

	// Use this for initialization
	void Start () {
		audios = GetComponents<AudioSource> ();
		bgm = audios[0];
		_gg = audios[1];
		_fin = audios[2];
//		_bgm = true;
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (_bgm) {
//			bgm.Play ();
//			_bgm = false;
//		}

		if (!isFinishSoundPlayed && Quest.currentQ == Quest.questType.Finish) {
			if(bgm.isPlaying)
				bgm.Stop ();
			_fin.Play ();
			isFinishSoundPlayed = true;
		} else if (!isGameOverSoundPlayed && Quest.currentQ == Quest.questType.GameOver) {
			if(bgm.isPlaying)
				bgm.Stop ();
			_gg.Play ();
			isGameOverSoundPlayed = true;
		}
	
	}
}
