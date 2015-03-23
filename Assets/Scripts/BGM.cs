using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	public AudioSource bgm, _fin, _gg;
	bool _bgm;

	// Use this for initialization
	void Start () {
		bgm = GetComponent<AudioSource> ();
		_fin = GetComponent<AudioSource> ();
		_gg = GetComponent<AudioSource> ();
		_bgm = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_bgm) {
			bgm.Play ();
			_bgm = false;
		}

		if (Quest.currentQ == Quest.questType.Finish) {
			bgm.Stop ();
			_fin.Play ();
		} else if (Quest.currentQ == Quest.questType.GameOver) {
			bgm.Stop ();
			_gg.Play ();
		}
	
	}
}
