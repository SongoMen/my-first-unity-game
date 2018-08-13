using UnityEngine;

public class PrzyciskiMenu : MonoBehaviour {

    public GameObject przyciskiContinueNewGame;
    public GameObject opcje;
    public GameObject glownePrzyciski;

    public bool opcjeTF = false;

    public void Play()
    {
        Application.LoadLevel("test");
    }
    public void ContinueNewGame()
    {
        przyciskiContinueNewGame.SetActive(true);
        glownePrzyciski.SetActive(false);
    }
    public void Options()
    {
        if(opcjeTF == false)
        {
            opcje.SetActive(true);
            opcjeTF = true;
        }
        else
        {
            opcje.SetActive(false);
            opcjeTF = false;
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
