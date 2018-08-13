using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int maxHealthE;
	public int curHealthE;

	private Player thePlayerStats;

	public int expToGive;
	// Use this for initialization
	void Start () {
		curHealthE = maxHealthE;

		thePlayerStats = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (curHealthE <= 0) {
			 Destroy(gameObject);
			thePlayerStats.AddExperience(expToGive);


		}
	}
	public void giveDamage(int damageToGive) {

		curHealthE -= damageToGive;
	}

	public void SetMaxHealth() {
		curHealthE = maxHealthE;
	}
	public void Damage(int damage)
	{
		curHealthE -= damage;

	}

}