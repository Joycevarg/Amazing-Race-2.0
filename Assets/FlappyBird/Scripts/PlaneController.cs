using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour {

    public Rigidbody player;
    public GameObject origin;
    public FlappyGameController gameController;
    public Animator animator;

    public Camera main;
    public float lift;
    public float gravity;

    //GameObject hitTarget;

    private void Start()
    {
    //    player.transform.position = origin.transform.position;
    }


    void Update ()
    {
        if (gameController.gameStarted)
        {
            player.AddForce(Vector3.up * (-gravity));
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray;
                ray = main.ScreenPointToRay(Input.mousePosition);//Input.GetTouch(0).position);
                Vector3 a, b;
                a = origin.transform.position - main.transform.position;
                a.z = 0;
                Vector3.Normalize(a);

                b = ray.direction;
                b.z = 0;

                Vector3.Normalize(b);

                b = (a - b) * lift;
                b.y = -b.y;
                b.x = -b.x;
                player.velocity = b;


                //RaycastHit rayhit;
                //if (Physics.Raycast(ray, out rayhit,1000f,2))
                //{
                //    hitTarget = rayhit.collider.gameObject;
                //    Debug.Log("Hit Something with tag "+hitTarget.tag);
                //    if (hitTarget.tag == "Target")
                //    {
                //        Destroy(hitTarget);
                //    }

                //}
            }
        }
    }
}
