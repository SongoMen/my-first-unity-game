using UnityEngine;
using System.Collections;

public class przyciski2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void level1A() {
		Application.LoadLevel("dungeon");
	}
	public void level2A() {
		Application.LoadLevel ("dungeon2");
	}
	public void level3A() {
		Application.LoadLevel ("dungeon3");
	}
}
