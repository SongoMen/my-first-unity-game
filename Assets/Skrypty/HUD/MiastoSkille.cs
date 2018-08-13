using UnityEngine;
using System.Collections;

public class MiastoSkille : MonoBehaviour {

	public GameObject canvas;

	private gameMaster gm;

	public bool active;
	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
		active = false;
		gm.inputText.text = (" ");
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("Player"))
		{
			gm.inputText.text = ("[E] to Select Level");
			if (Input.GetKeyDown("e"))
			{
				canvas.SetActive (true);
				active = true;

			}
			if (active == true){
				if (Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.Escape)) {

				}
				canvas.SetActive (false);
				active = false;
			}

		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			gm.inputText.text = ("[E] to Select Level");
			if (Input.GetKeyDown("e"))
			{
				canvas.SetActive (true);
				active = true;

			}
			if (active == true){
				if (Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.Escape)) {

				}
				canvas.SetActive (false);
				active = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			gm.inputText.text = (" ");
		}
	}
}
