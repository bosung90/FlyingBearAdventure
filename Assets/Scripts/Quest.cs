using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public enum questType {Quest1, Quest2, Quest3, Quest4, Finish};
	public GameObject _bombPrefab, _dataPrefab;
	public Transform camera;
	public static questType currentQ;
	bool _hasBomb, _posted;
	public GameObject[] _marked, _checked;


	// Use this for initialization
	void Start () {
		currentQ = questType.Quest1;
		_hasBomb = false;
		_posted = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		_marked = GameObject.FindGameObjectsWithTag("mark");


		if (_marked.Length == 0 && _posted) {
			currentQ = questType.Finish;
			Debug.Log ("CurrentQuest : finished");
			_posted = false;
		}
	
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag != "undefined") {
			Debug.Log ("Currently touching : " + collision.gameObject.tag);
		}

		if(collision.gameObject.tag == "testing") {
			collision.gameObject.tag = "checked";
		}

		if (currentQ == questType.Quest1 && collision.gameObject.tag == "data") {
			currentQ = questType.Quest2;
			Destroy (collision.gameObject);
			Debug.Log ("CurrentQuest : quest2 entered");
		} else if (currentQ == questType.Quest2 && collision.gameObject.tag == "comp") {
			currentQ = questType.Quest3;
			GameObject newData = Instantiate (_dataPrefab) as GameObject;
			newData.transform.position = this.transform.position + camera.transform.forward;
			Debug.Log ("CurrentQuest : quest3 entered");
		} else if (currentQ == questType.Quest3 && collision.gameObject.tag == "bomb") {
			currentQ = questType.Quest4;
			_hasBomb = true;
			Destroy (collision.gameObject);
		} else if (currentQ == questType.Quest3 && collision.gameObject.tag == "mark" && _hasBomb) {
			GameObject newBomb = Instantiate (_bombPrefab) as GameObject;
			Vector3 _pos = collision.gameObject.transform.position;
			newBomb.transform.position = new Vector3 (_pos.x, _pos.y + 0.1f, _pos.z);
			collision.gameObject.tag = "marked";
		}		
	}



}
