using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public DartsGameController gameController;
    public Transform origin;
    public GameObject board;
    Rigidbody rb;

    public float scoreMultiplier;
    public float magnitude;
    public float maxDist = 0.8f;
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        magnitude = Vector3.Magnitude(other.transform.position - origin.position);
        other.enabled = false;
        other.gameObject.transform.parent = board.transform;
        score =(int)( (maxDist - magnitude) * scoreMultiplier);
        gameController.points += score;
        gameController.PointUpdate();
    }
}

