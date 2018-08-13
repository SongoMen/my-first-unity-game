using System;
using UnityEngine;

public class pause : MonoBehaviour
{
	public bool gamePaused = false;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gamePaused) {
				Time.timeScale = 1;
				gamePaused = false;
			} else {
				Time.timeScale = 0;
				gamePaused = true;
			}
		}
	}
	void OnGUI()
	{
			if(gamePaused) {
				Color background = Color.black;
				background.a = 0.3f;
				DrawQuad(new Rect(0, 0, Screen.width, Screen.height), background);
				if(GUI.Button(new Rect(Screen.width / 2 - 50, 20, 100, 20), "Graj")) {

				}
				if(GUI.Button(new Rect(Screen.width / 2 - 50, 50, 100, 20), "Opcje")) {

				}
				if(GUI.Button(new Rect(Screen.width / 2 - 50, 80, 100, 20), "Wyjdz")) {

			}
		}
	}

	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
		bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}
