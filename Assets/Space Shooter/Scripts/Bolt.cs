using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    ShooterGameController gameController;
    public GameObject explosion;

    private void Start()
    {
        gameController= GameObject.FindGameObjectWithTag("GameController").GetComponent<ShooterGameController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.score += 1;

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
