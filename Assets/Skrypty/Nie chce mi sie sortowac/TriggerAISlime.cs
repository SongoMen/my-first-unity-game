using UnityEngine;
using System.Collections;

public class TriggerAISlime : MonoBehaviour {

    public AISlime ai;

    public bool prawa;

    

	void Start () {
        ai = GetComponentInParent<AISlime>();
	}
	

	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
          if(prawa == true)
            {
                ai.GraczWZasieguPrawa(true);
                ai.GraczWZasieguLewa(false);
            }
            else
            {
                ai.GraczWZasieguPrawa(false);
                ai.GraczWZasieguLewa(true);
            }

        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (prawa == true)
            {
                ai.GraczWZasieguPrawa(true);
                ai.GraczWZasieguLewa(false);
                Debug.Log("Prawa");
            }
            else
            {
                ai.GraczWZasieguPrawa(false);
                ai.GraczWZasieguLewa(true);
                Debug.Log("Lewa");
            }

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (prawa == true)
            {
                ai.GraczWZasieguPrawa(false);
            }
            else
            {
                ai.GraczWZasieguLewa(false);
            }
        }
    }

}
