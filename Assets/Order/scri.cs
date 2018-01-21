using UnityEngine;

public class scri : MonoBehaviour {
    GameController gameController;
    Animator anim;
    int noleft;
    bool gameOver = false;

    // Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        noleft = 4;
        gameController = GameController.gameController;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (noleft == 0 && !gameOver)
        {
            gameOver = true;
            gameController.MakeClueAvailable();
            gameController.Save();
            gameController.LoadScene(0);
        }
	}
    public void animate(int no)
    {
        if (noleft == no)
        {
            anim.SetTrigger("right");
            noleft--;
        }
        else
        {
            anim.SetTrigger("wrong");
            noleft = 4;
            Handheld.Vibrate();
        }

    }
    public void displeft()
    {
        Debug.Log(noleft);
    }
}
