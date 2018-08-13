using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //int
    public int playerGold { get; set; }
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int curHealth;
    public int maxHealth = 5;
    public int skillPoint;

    //Floats
    private float gravityStore;
    private float climbVelocity;
    public float climbSpeed;
    public float speed = 50f;
    public float maxSpeed = 3;
    public float jumpPower = 1500f;

    //Booleans
    public bool onLadder;
    public bool grounded;
    public bool canDoubleJump;
    public bool justJumped = false;

    //References
	public Image hp6a;
	public Image hp7a;
	public Image hp8a;

	public Image hp6;
	public Image hp7;
	public Image hp8;

    private Rigidbody2D rb2d;

    public Text coinsText;

    private Animator animator;

    public float test;

	private pause pa;

    private gameMaster gm;

    // Use this for initialization
    void Start()
    {
		hp6.enabled = false;
		hp7.enabled = false;
		hp8.enabled = false;
		hp6a.enabled = false;
		hp7a.enabled = false;
		hp8a.enabled = false;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        animator = gameObject.GetComponentInChildren<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
		pa = gameObject.GetComponent<pause>();
        playerGold = 100;
        gravityStore = rb2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
		//dodatkowe życie
		if (curHealth == 5 && maxHealth == 8) {
			hp6a.enabled = true;
			hp7a.enabled = true;
			hp8a.enabled = true;
		}
		if (curHealth == 5 && maxHealth == 7) {
			hp6a.enabled = true;
			hp7a.enabled = true;
		}
		if (curHealth == 5 && maxHealth == 6) {
			hp6a.enabled = true;
		}
		if (curHealth == 6 && maxHealth == 8) {
			hp6.enabled = true;
			hp7a.enabled = true;
			hp8a.enabled = true;
		}
		if (curHealth == 6 && maxHealth == 7) {
			hp6.enabled = true;
			hp7a.enabled = true;
		}
		if (curHealth == 6 && maxHealth == 6) {
			hp6a.enabled = true;
		}
		if (curHealth == 7 && maxHealth == 8) {
			hp6.enabled = true;
			hp7.enabled = true;
			hp8a.enabled = true;
		}
		if (curHealth == 7 && maxHealth == 7) {
			hp6.enabled = true;
			hp7.enabled = true;
		}
		if (curHealth == 7 && maxHealth == 6) {
			hp6a.enabled = true;
		}
		if (curHealth == 8 && maxHealth == 8) {
			hp6.enabled = true;
			hp7.enabled = true;
			hp8.enabled = true;
		}
        //dzwieki chodzenia
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
			if (grounded && pa.gamePaused == false) {
                GetComponent<AudioSource>().UnPause();
            }
            if (!grounded) {
                GetComponent<AudioSource>().Pause();
            }
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }
        //levele
        if (currentExp >= toLevelUp[currentLevel]) {
            currentLevel++;
            skillPoint++;
        }

        coinsText.text = (" " + playerGold);
        //skakanie


        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
                justJumped = true;
            }


            else
            {
                if (canDoubleJump == true)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.50f);
                }
            }
        }

        //życie

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
            Die();


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        //sprint

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 450;

        }
        else
        {
            speed = 300;
        }

        if (onLadder)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb2d.gravityScale = 0f;
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                rb2d.velocity = new Vector2(rb2d.velocity.x, climbSpeed);
                jumpPower = 0;
            }
        }
        if (onLadder)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb2d.gravityScale = 0f;
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                rb2d.velocity = new Vector2(rb2d.velocity.x, climbSpeed);
                jumpPower = 0;
            }
        }

        if (!onLadder) {
            rb2d.gravityScale = gravityStore;
        }

    }
    public void giveDamage(int damageToGive) {

        curHealth -= damageToGive;
    }

    void FixedUpdate()
    {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        float h = Input.GetAxisRaw("Horizontal");
        test = Input.GetAxisRaw("Horizontal");

        if (grounded) rb2d.velocity = easeVelocity;

        rb2d.AddForce((Vector2.right * speed) * h);

        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
        curHealth = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) {
            Destroy(col.gameObject);
            playerGold += 30;
        }

    }
    void OnGUI()
    {
        GUI.Label(new Rect(20, 0, 100, 20), "Max HP: " + maxHealth);
        GUI.Label(new Rect(20, 50, 100, 20), "Skill Points: " + skillPoint);
    }
    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;

    }
    public void changePlayerStat(string name, float value)
    {
        switch (name) {
            case "maxHealth":
                maxHealth = (int)value;
                break;
        }

    }
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;
    }
}