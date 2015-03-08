using UnityEngine;
using System.Collections;

public class Shelf : MonoBehaviour {

	public GameObject box;
	public GameObject supp;
	Vector3 _pos;
	string name;

	// Use this for initialization
	void Start () {
		_pos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 1f);
		name = this.gameObject.name;
		for(int i = 0; i < 20; i++) {
			GameObject _box = Instantiate(box);
			_box.transform.position = _pos;
			_pos = new Vector3(_pos.x, _pos.y, _pos.z + 1);
			if(this.gameObject.name == "Shelf" || this.gameObject.name == "Shelf 1") {
				float rnd = Random.Range(0f, 5f);
				Debug.Log (rnd);
				if(rnd > 4f) {
					GameObject _supp = Instantiate(supp);
					float height = 1.5f;
					_supp.transform.position = new Vector3(_box.transform.position.x, height, _box.transform.position.z + 1);
				}
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
