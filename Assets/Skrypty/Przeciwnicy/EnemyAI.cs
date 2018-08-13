using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	public int damageToGive = 1;
    public Transform[] patrol;
    private int Currentpoint;
    public float moveSpeed;
	public bool playerInCollider;

	private Rigidbody2D rb2d;

	private Player player;

    void Start()
    {	
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
        transform.position = patrol[0].position;
        Currentpoint = 0;
    }
    void Update()
	{

			if (transform.position == patrol [Currentpoint].position) {
				Currentpoint++;
			}

			if (Currentpoint >= patrol.Length) {
				Currentpoint = 0;
			}

			transform.position = Vector3.MoveTowards (transform.position, patrol [Currentpoint].position, moveSpeed * Time.deltaTime);
		}
	}

