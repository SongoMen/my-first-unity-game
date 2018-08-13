using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public int LeveltoLoad;
    private gameMaster gm;
	public bool level1;
	public bool level2;

	// Use this for initialization
	void Start () {
		Scene currentScene = SceneManager.GetActiveScene ();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
		string sceneName = currentScene.name;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {
				Scene currentScene = SceneManager.GetActiveScene ();
				string sceneName = currentScene.name;
                Application.LoadLevel(LeveltoLoad);
				if (sceneName == "dungeon") {
					level1 = true;

				} 
				else {
					level1 = false;
				}
				if (sceneName == "dungeon2") {
					level2 = false;
				}
				else {
					level2 = false;
				}

            }


        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                Application.LoadLevel(LeveltoLoad);
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
