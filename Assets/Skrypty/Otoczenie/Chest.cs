using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

	public Text chestText;
    private Animator animator;
    public Vector3 spawnSpot = new Vector3(0, 2, 0);
    public GameObject coin;
	private bool open;

	// Use this for initialization

	void Start () {
		open = false;
        animator = gameObject.GetComponent<Animator>();
		chestText.text = ("  ");
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			chestText.text = ("[E] to Open");
			if (Input.GetKeyDown ("e") && open == false) {
				open = true;
                GameObject coinSpawn = (GameObject)Instantiate(coin, new Vector3(0, 2, 0), transform.rotation);


            }
		}

	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			if (Input.GetKeyDown("e") && open == false)
			{
				open = true;
                animator.SetTrigger("open");
			}

		}
	
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			chestText.text = (" ");
		}
	}
}