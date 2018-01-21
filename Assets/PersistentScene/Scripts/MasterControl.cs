using UnityEngine;
using UnityEngine.UI;

public class MasterControl : MonoBehaviour
{
    public InputField input;

    public Animator animator;

    GameController gameController;
	// Use this for initialization
	void Start ()
    {
        gameController = GameController.gameController;
	}
	
	public void PasswordEntry()
    {
        if (input.text == "24Carat")
        {
            animator.SetTrigger("Confirm");
        }
        else
        {
            gameController.LoadScene(0);
        }
    }

    public void MakeClueAvailable()
    {
        gameController.MakeClueAvailable();
        gameController.LoadScene(0);

    }

    public void LoadScene(int SceneIndex)
    {
        gameController.LoadScene(SceneIndex);
        gameController.LoadScene(0);

    }

    public void DeleteSave()
    {
        gameController.DeleteSave();
        gameController.LoadScene(0);

    }

    public void RemoveBlackout()
    {
        //gameController.RemoveBlackout();
        gameController.LoadScene(0);

    }
    public void SendData()
    {
        //gameController.SendData();
        gameController.LoadScene(0);

    }
}
