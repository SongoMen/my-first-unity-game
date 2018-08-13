using UnityEngine;
using System.Collections;

public class pasekZycia : MonoBehaviour {

	public float currentHealth = 100.0f;
	private float maxHealth = 100.0f;
	private float canHeal = 0.0f;

	public Texture2D healthTexture;
    public Texture2D ramkaTexture;

    private float szerokoscGuzikow = 0f;
    private float wysokoscGuzikow = 0f;

    void Start()
    {
        szerokoscGuzikow = Screen.width / 12;
        wysokoscGuzikow = Screen.height / 32;
    }

    void Update () {
		//if(Input.GetButtonDown("Fire1")) {
		//	currentHealth -= 10;
		//	canHeal = 5.0f;
		//}

		if(canHeal > 0.0f) {
			canHeal -= Time.deltaTime;
		}

		if(canHeal <= 0.0f) {
			if(currentHealth < maxHealth) {
				currentHealth += maxHealth * 0.01f;
				StartCoroutine("heal");
			}
			Mathf.Clamp(currentHealth, 0, maxHealth);
		}

		if(currentHealth <= 0) {
            currentHealth = 0;
			Debug.Log ("Trup!");
		}

	}

	void OnGUI() 
	{
		GUI.DrawTexture(new Rect(10, 10, currentHealth * 100 / maxHealth * szerokoscGuzikow/35, wysokoscGuzikow*3.5f), healthTexture);
        GUI.DrawTexture(new Rect(10, 10, szerokoscGuzikow*maxHealth/35, wysokoscGuzikow*3.5f), ramkaTexture);
    }
	

	IEnumerator heal() 
	{
		yield return new WaitForSeconds(0.5f);
	}
}
