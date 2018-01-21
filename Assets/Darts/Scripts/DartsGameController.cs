
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DartsGameController : MonoBehaviour
{


    public GameObject ball;
    public Camera main;
    public Transform spawnPoint;
    public int points = 0;
    public Text scoreText;
    public Text dartText;
    public Text infoText;

    public int clueIndex;

    public bool gameOver=false;
    public int DartNo = 5;
    public int winScore = 20;

    GameController gameController;

    public bool isHolding = false;
    // Use this for initialization
    void Start()
    {
        scoreText.text = "Score : 0 ";
        gameController = GameController.gameController;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHolding && DartNo>0)
        {
            if (Input.GetMouseButtonDown(0))//Input.GetTouch(0).phase==TouchPhase.Began)
            {
                isHolding = true;
                //Vector3 offset = new Vector3(0, 1f, 0.1f);
                Instantiate(ball, spawnPoint.position, main.transform.rotation, spawnPoint.gameObject.transform);
                DartNo--;
                dartText.text = "Darts : " + DartNo;
            }
        }
    }

    public void PointUpdate()
    {
        scoreText.text = "Score : " + points;
        if (points >= winScore && !gameOver)
        {
            gameOver = true;
            gameController.MakeClueAvailable();
            gameController.Save();
            gameController.LoadScene(0);
        }
    }
    public void ResetCount()
    {
        DartNo = 5;
        dartText.text = "Darts : " + DartNo;
    }

    public void ToggleInfo()
    {
        if (infoText.gameObject.activeInHierarchy)
        {
            infoText.gameObject.SetActive(false);
        }
        else
        {
            infoText.gameObject.SetActive(true);
        }
    }
}
