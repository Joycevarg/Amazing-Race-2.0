using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour {

    public float speedMultiplier;
    public float tilt;
    public float xTilt;
    public Vector3 velocity;
    float holdTime = 0f;
    bool isHolding = true;

    Rigidbody ball;
    DartsGameController gameController;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<DartsGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.rotation = Quaternion.Euler(ball.velocity.y*tilt, ball.velocity.x*xTilt, 0f);
        if (isHolding)
        {
            if (Input.GetMouseButton(0))//*/Input.GetTouch(0).phase!=TouchPhase.Ended)
            {
                isHolding = true;
                gameController.isHolding = true;
                holdTime += Time.deltaTime;
                holdTime = Mathf.Clamp(holdTime, 0f, 3f);
                
            }
            else if (Input.GetMouseButtonUp(0))//Input.GetTouch(0).phase==TouchPhase.Ended)
            {

                isHolding = false;
                gameController.isHolding = false;
                /*
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 rotator = camRay.direction.normalized;

                rotator.Set(
                    Mathf.Acos(rotator.x) * Mathf.Rad2Deg,
                    Mathf.Acos(rotator.y) * Mathf.Rad2Deg,
                    Mathf.Acos(rotator.z) * Mathf.Rad2Deg
                    );
                */
                //Vector3 direction;
                Ray target;
                //if (Input.GetMouseButtonUp(1))
                {
                    target = Camera.main.ScreenPointToRay(Input.mousePosition);
                }
                
                //else
                //{
                //    target = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //}
                
                //direction = spawn.direction - target.direction;
                //direction.Set(direction.x, 0, direction.z);

                //Vector3.Normalize(direction);

                ball.velocity = Vector3.Normalize(target.direction) * holdTime * speedMultiplier + velocity;
                ball.useGravity = true;
            }
        }
    }
}
