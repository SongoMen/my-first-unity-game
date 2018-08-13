using UnityEngine;
using System.Collections;

public class Canvas : MonoBehaviour {

	public GameObject canvas;

	public bool active;
	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (active == false){
			canvas.SetActive (true);
				active = true;
			}
			else {
				canvas.SetActive (false);
				active = false;
			}
		}

	}
}
