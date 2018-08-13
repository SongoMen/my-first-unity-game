using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public string obecneOkno = "menuGlowne";
    Vector2 srodekEkranu;
    private float szerokoscGuzikow = 0f;
    private float wysokoscGuzikow = 0f;
    public GUISkin GUIDomyslne;

    void Start () {
        srodekEkranu = new Vector2(Screen.width / 2, Screen.height / 2);
        szerokoscGuzikow = Screen.width / 6;
        wysokoscGuzikow = Screen.height / 16;
    }
	

	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = GUIDomyslne;
        switch (obecneOkno)
        {
            case "menuGlowne":
                MenuGlowne();
                break;
            case "wyborPoziomu":
                WyborPoziomu();
                break;
        }
    }

    void MenuGlowne()
    {
        if (GUI.Button(new Rect(Screen.width / 10 - szerokoscGuzikow * 0.1f, Screen.height / 8 - szerokoscGuzikow * 0.05f, szerokoscGuzikow, wysokoscGuzikow), "Play", "przycisk"))
        {
            obecneOkno = "wyborPoziomu";
        }
        if (GUI.Button(new Rect(Screen.width / 10, Screen.height / 8 + wysokoscGuzikow, szerokoscGuzikow * 0.8f, wysokoscGuzikow * 0.8f), "Options", "przycisk"))
        {

        }
        if (GUI.Button(new Rect(Screen.width / 10, Screen.height / 8 + wysokoscGuzikow * 2, szerokoscGuzikow * 0.8f, wysokoscGuzikow * 0.8f), "Exit", "przycisk"))
        {
            Application.Quit();
        }
    }

    void WyborPoziomu()
    {
        if (GUI.Button(new Rect(Screen.width / 10, Screen.height / 8, szerokoscGuzikow * 0.8f, wysokoscGuzikow * 0.8f), "Test", "przycisk"))
        {
            Application.LoadLevel("test");
        }
    }
}
