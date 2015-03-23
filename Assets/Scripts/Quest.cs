using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public enum questType {Quest1, Quest2, Quest3, Quest4, Finish, GameOver};
	public GameObject _bombPrefab, _dataPrefab;
	public Transform camera;
	public static questType currentQ;
	bool _hasBomb, _posted;
	public GameObject[] _marked, _checked;

	private float health = 100;

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

		if(currentQ == questType.GameOver)
		{
//			Destroy(this.gameObject);
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
			newData.transform.position = collision.transform.position + Vector3.right;
			Debug.Log ("CurrentQuest : quest3 entered");
		} else if (currentQ == questType.Quest3 && collision.gameObject.tag == "bomb") {
			currentQ = questType.Quest4;
			_hasBomb = true;
			Destroy (collision.gameObject);
		} else if (currentQ == questType.Quest4 && collision.gameObject.tag == "mark" && _hasBomb) {
			GameObject newBomb = Instantiate (_bombPrefab) as GameObject;
			Vector3 _pos = collision.gameObject.transform.position;
			newBomb.transform.position = collision.transform.position + Vector3.up;
			collision.gameObject.tag = "marked";
		}		
	}

	void TakeDamage(float damage)
	{
		health -= damage;
		if(health <=0 )
		{
			currentQ = questType.GameOver;
		}
	}


}
