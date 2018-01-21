using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryControl : MonoBehaviour {
    public FlappyGameController gameController;
    public Animator animator;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something Exited");
        if (other.tag == "Player")
        {
            if (gameController.gameStarted)
            {
                Debug.Log("Exited the Collider");
                animator.SetTrigger("GameOver");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Entered");
        if (other.tag == "Player")
        {
            Debug.Log("Entered the Collider");
        }
    }
}
