using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Przyciski : MonoBehaviour {

	private Player ps;
	public Button hp1a;
	public Button hp2a;
	public Button hp3a;

	// Use this for initialization
	void Start () {

		ps = gameObject.GetComponent<Player> ();

	}

	public void hp1 () {
		if (ps.skillPoint <= 1) {
			hp1a.interactable = false;
		}
		if (ps.skillPoint >= 1) {
			hp1a.interactable = true;
			ps.maxHealth = 6;
		}
	}
	public void hp2 () {
		if (ps.skillPoint <= 3) {
			hp2a.interactable = false;
		}
		if (ps.skillPoint >= 3) {
			hp2a.interactable = true;
			ps.maxHealth = 7;
		}
		if (hp2a.interactable == true) {

		}
	}
	public void hp3 (){
		if (ps.skillPoint <= 5) {
			hp3a.interactable = false;
		}
		if (ps.skillPoint >= 5) {
			hp3a.interactable = true;
			ps.maxHealth = 8;
		}
	}	
}
