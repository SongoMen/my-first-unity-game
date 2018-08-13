using UnityEngine;


public class zapadajacaSiePlatforma : MonoBehaviour {

    public GameObject colider;
    public bool ruchWDol = false;
    public bool timerZniszczenia = false;
    public float timerF;

    private Rigidbody2D rb;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (ruchWDol == true)
        {
            rb.AddForce(Vector2.down * 10);
        }
        if (timerZniszczenia == true)
        {
            timerF += Time.deltaTime;
        }
        if (timerF >= 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            colider.SetActive(false);
            ruchWDol = true;
            timerZniszczenia = true;
        }
    }

}
