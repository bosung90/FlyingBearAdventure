using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public enum questType {Quest1, Quest2, Quest3, Finish};
	GameObject _bombPrefab, _dataPrefab;
	Transform camera;
	questType currentQ;


	// Use this for initialization
	void Start () {
		currentQ = questType.Quest1;
	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject[] _marked = GameObject.FindGameObjectsWithTag ("mark");


		if (_marked == null) {
			currentQ = questType.Finish;
			this.transform.position = new Vector3(0,0,0);
		}
	
	}

	void OnCollisionEnter(Collision collision) {
		if (currentQ == questType.Quest1 && collision.gameObject.tag == "data") {
			currentQ = questType.Quest2;
			Destroy (collision.gameObject);
		} else if (currentQ == questType.Quest2 && collision.gameObject.tag == "comp") {
			currentQ = questType.Quest3;
			GameObject newData = Instantiate (_dataPrefab);
			newData.transform.position = this.transform.position + camera.transform.forward;
		} else if (currentQ == questType.Quest3 && collision.gameObject.tag == "mark") {
			GameObject newBomb = Instantiate (_bombPrefab);
			Vector3 _pos = collision.gameObject.transform.position;
			newBomb.transform.position = new Vector3 (_pos.x, _pos.y + 0.1f, _pos.z);
			collision.gameObject.tag = "marked";
		}		
	}



}
