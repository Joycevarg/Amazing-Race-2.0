using UnityEngine;
using System.Collections;

public class FlappyGameController : MonoBehaviour
{

    GameController gameController;
    //public int sceneIndex = 2;
    public int clueIndex = 1;

    public PlaneController planeController;
    public GameObject gamePlane;
    public Transform gameTransform;
    public Transform startTransform;
    public Transform endTransform;
    public Transform endStartTransform;
    public Collider planeCollider;

    public float motionTime = 3f;

    bool motion;
    bool endMotion;
    bool positionSet = false;
    public bool gameStarted = false;
    public bool gameEnded = false;


    public float timeCount=0f;

    private void Start()
    {
        gameController = GameController.gameController;
    }

    private void Update()
    {

        #region StartMotionControl
        if (motion)
        {
            if (!positionSet)
            {
                if (timeCount == 0f)
                {
                    gamePlane.transform.parent = gameTransform;
                    timeCount += Time.deltaTime;
                }
                else if (timeCount < motionTime)
                {

                    gamePlane.transform.position = Vector3.Lerp(startTransform.position, gameTransform.position, timeCount / motionTime);
                    gamePlane.transform.rotation = Quaternion.Lerp(startTransform.rotation, gameTransform.rotation, timeCount / motionTime);
                    timeCount += Time.deltaTime;
                }
                else
                {
                    Debug.Log("Finished Lerping");
                    gamePlane.transform.rotation = gameTransform.rotation;
                    gamePlane.transform.position = gameTransform.position;
                    positionSet = true;
                }
            }
            else if (!gameStarted)
            {
                Debug.Log("Game Started");
                //animator.SetTrigger("Countdown");
                planeController.enabled = true;
                planeController.GetComponent<Rigidbody>().drag = 0;
                gamePlane.transform.localPosition = Vector3.zero;
                gameStarted = true;
                planeCollider.enabled = true;
                motion = false;
            }

        }
        #endregion

        
        #region EndMotionControl
        if (endMotion)
        {
            endStartTransform.position = gamePlane.transform.position;
            endStartTransform.rotation = gamePlane.transform.rotation;
            if (!positionSet)
            {
                if (timeCount == 0f)
                {
                    gamePlane.transform.parent = endTransform.parent;
                    timeCount += Time.deltaTime;
                }
                else if (timeCount < motionTime)
                {
                    gamePlane.transform.position = Vector3.Lerp(endStartTransform.position, endTransform.position, timeCount / motionTime);
                    gamePlane.transform.rotation = Quaternion.Lerp(endStartTransform.rotation, endTransform.rotation, timeCount / motionTime);
                    timeCount += Time.deltaTime;
                }
                else
                {
                    Debug.Log("Finished Lerping");
                    gamePlane.transform.rotation = endTransform.rotation;
                    gamePlane.transform.position = endTransform.position;
                    positionSet = true;
                }
            }
            else if (!gameEnded)
            {
                Debug.Log("Game Ended");
                //animator.SetTrigger("Countdown");
                gameEnded = true;
                endMotion = false;
                gameController.MakeClueAvailable();
                gameController.Save();
                
                //gameController.LoadScene(0);//Default AR Scene
            }

        }
        #endregion



    }

    public void Motion()
    {
        motion = true;
        gamePlane.GetComponent<MeshRenderer>().enabled = true;
    }
    public void EndGame()
    {
        if (gameStarted)
        {
            planeController.GetComponent<Rigidbody>().isKinematic = true;
            planeController.enabled = false;
            endMotion = true;
            positionSet = false;
            timeCount = 0;
        }
    }

    public void Reset()
    {
        gameController.LoadScene(0);
    }



}
