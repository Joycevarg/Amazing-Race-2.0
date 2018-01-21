using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerMover : MonoBehaviour {

    public ShooterGameController gameController;
    public float speed;

    Rigidbody rb;
    float moveHorizontal;
    float moveVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        moveHorizontal = CnInputManager.GetAxis("Horizontal");
        moveVertical = CnInputManager.GetAxis("Vertical");
        rb.velocity = new Vector3(moveHorizontal, 0f, moveVertical) * speed;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            gameController.ResetGame(); 
        }
    }
}
