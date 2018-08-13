using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public bool attacking = false;

	private GameObject target;
    public float attackTimer = 0;
    public float attackCd = 0.4f;

    public Collider2D Atak;

    private Animator Animator;

    void Awake() {


        Animator = gameObject.GetComponent<Animator>();
        Atak.enabled = false;
            }
	void Update () {
        if (Input.GetKeyDown (KeyCode.X) && attacking == false) 
        {
            attacking = true;
            attackTimer = attackCd;

            Atak.enabled = true;

            Animator.SetTrigger("attack");
            Debug.Log("Atak");
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                Atak.enabled = false;

            }



        }

	}
	}
