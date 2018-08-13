using UnityEngine;
using System.Collections;

public class ObracajSiePostacio : MonoBehaviour {

    public bool right = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && right == true)
        {
            transform.Rotate(Vector3.up * 180);
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && right == false)
        {
            transform.Rotate(Vector3.up * 180);
            right = true;
        }
		if (Input.GetKeyDown(KeyCode.A) && right == true)
		{
			transform.Rotate(Vector3.up * 180);
			right = false;
		}
		if (Input.GetKeyDown(KeyCode.D) && right == false)
		{
			transform.Rotate(Vector3.up * 180);
			right = true;
		}
    }
		
	void RotateLeft () {
		transform.Rotate (Vector3.forward * -90);
	}
}