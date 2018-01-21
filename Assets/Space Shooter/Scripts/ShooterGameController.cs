using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ShooterGameController : MonoBehaviour {

    GameController gameController;
    public float spawnDelay = 5f;
    public List<Transform> spawnTransforms;
    public MeshRenderer meshRenderer;

   // public GameObject disabler;

    public GameObject asteroid;
    public GameObject laser;
    public Transform laserSpawn;

    public float timer = 0f;
    public int score = 0;
    bool gameOver = false;
    // Use this for initialization
	void Start ()
    {
        gameController = GameController.gameController;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(meshRenderer.isVisible)
        {
           // disabler.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= spawnDelay)
            {
                Instantiate(asteroid, spawnTransforms[((int)Random.Range(0, spawnTransforms.Count)) % spawnTransforms.Count], false);
                timer = 0f;
            }
        }

        if (!gameOver && score>= 10)
        {
            gameOver = true;
            gameController.MakeClueAvailable();
            gameController.Save();
            gameController.LoadScene(0);
        }

	}
    public void ResetGame()
    {
        gameController.LoadScene(5);
    }

    public void Fire()
    {
        if (meshRenderer.isVisible)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
        }
    }
}
