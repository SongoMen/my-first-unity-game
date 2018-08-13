using UnityEngine;
using System.Collections;

public class PlynnaKamera : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject Player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float posX = Mathf.SmoothDamp (transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);
	
	}
}
