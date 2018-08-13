using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<Player>();
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player"))
        {
            player.giveDamage(1000);

            StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }
	
	}
}
