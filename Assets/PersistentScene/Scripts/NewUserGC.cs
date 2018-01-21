using UnityEngine;
using UnityEngine.UI;

public class NewUserGC : MonoBehaviour
{
    public GameController gameController;
    public InputField input;
    public Button submit;


    private void Start()
    {
        gameController = GameController.gameController;
    }
    private void Update()
    {
        if (input.text == "")
        {
            submit.interactable = false;
        }
        else
        {
            submit.interactable = true;
        }
    }
    public void SaveUserName()
    {
        int num;
        int.TryParse(input.text, out num);
        gameController.playerNo =num;
        Debug.Log("PlayerNo = " + gameController.playerNo);
        gameController.outString = ";" + num + ";";

        gameController.Save();
    }

    public void RegisterFirstClue(int clueNo)
    {
        gameController.availableClues.Add(clueNo);
        gameController.currentClue = clueNo;
        gameController.Save();
        gameController.LoadScene(0);
    }

}
