using UnityEngine;
using CnControls;

public class Helicontrol : MonoBehaviour {
    private Rigidbody rb;

    private GameController gameController;

    public GameObject explosionVFX;
    public GameObject bomb;
    public Transform bombSpawn;
    public float speed;
    public float tilt;

    bool gameOver=false;

    public int score=0; 

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameController.gameController;
	}

    // Update is called once per frame
    private void Update()
    {
        if (score >= 6 && !gameOver)
        {
            gameOver = true;
            gameController.MakeClueAvailable();
            gameController.Save();
            gameController.LoadScene(0);
        }
    }
    void FixedUpdate()
    {
        float moveH = CnInputManager.GetAxis("Horizontal");
        float moveV = CnInputManager.GetAxis("Vertical");

        Vector3 rotation = new Vector3(0.0f, moveH*tilt, 0f);

        rb.transform.Rotate(rotation);
        Vector3 movement = rb.transform.right * moveV * speed;
        rb.velocity=movement;
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tower")
        {
            Instantiate(explosionVFX, this.transform.position,this.transform.rotation);
            Reset();
            this.gameObject.SetActive(false);
        }
    }

    public void BombInit()
    {
        Instantiate(bomb, bombSpawn.position,bombSpawn.rotation);
    }

    public void Reset()
    {
        gameController.LoadScene(4);
    }
}
