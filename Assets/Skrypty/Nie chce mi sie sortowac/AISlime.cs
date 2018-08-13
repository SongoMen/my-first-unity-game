using UnityEngine;
using System.Collections;

public class AISlime : MonoBehaviour {

    GameObject player;
    Rigidbody2D rb2d;
    public int jumpPower;
    public int powerChodzenia;
    public float timerSkoku;

    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

	void Update () {
        timerSkoku += Time.deltaTime;
	}

    public void GraczWZasieguLewa(bool Bool)
    {
        if(Bool == true)
        {
            if (Mathf.Abs((transform.position - player.transform.position).x) >= 1 && timerSkoku >= 1f)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                rb2d.AddForce(Vector2.left * powerChodzenia);
                timerSkoku = 0f;
            }
        }
    }
    public void GraczWZasieguPrawa(bool Bool)
    {
        if (Bool == true)
        {
            if (Mathf.Abs((transform.position - player.transform.position).x) >= 1 && timerSkoku >= 1f)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                rb2d.AddForce(Vector2.left * powerChodzenia);
                timerSkoku = 0f;
            }
        }
    }
}
