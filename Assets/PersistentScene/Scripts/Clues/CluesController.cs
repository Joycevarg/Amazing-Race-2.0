using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CluesController : MonoBehaviour {

    
    GameController gameController;
    public Canvas panel;
    public RawImage clueImage;
    public Text clueText;
    public Text clueNo;
    public int currentClueDisp=-1;

    //public Animator animator;
    List<int> availableClues;
    List<GameController.Clue> clues;
    
    private void Start()
    {
        gameController = GameController.gameController;
        clues = gameController.clues;
        availableClues = gameController.availableClues;
    }

        public void NextClue()
    {
        if (availableClues.Count != 0)
        {

            currentClueDisp = (currentClueDisp + 1) % availableClues.Count;
            clueNo.text = "Clue No : " + (currentClueDisp + 1);
            //clueImage.texture = clues[availableClues[currentClueDisp]].image;
            DisplayClue(currentClueDisp);
        }
    }

    public void PrevClue()
    {
        int clueCount = gameController.availableClues.Count;

        if (clueCount != 0)
        {
            currentClueDisp = (currentClueDisp + clueCount - 1) % clueCount;
            clueNo.text = "Clue No : " + (currentClueDisp + 1);
            DisplayClue(currentClueDisp);
        }
    }

    public void DisplayClue(int currentClue)
    {
        if (availableClues.Count == 0)
        {
            return;
        }
        if (currentClueDisp == -1)
        {
            currentClueDisp = 0;
        }
        if (!clues[availableClues[currentClue]].image)
        {
            clueImage.gameObject.SetActive(false);
            clueText.gameObject.SetActive(true);
            clueText.text = clues[availableClues[currentClue]].text;
            if (clues[availableClues[currentClue]].text == "")
                clueNo.text = "";
            else
                clueNo.text = "Clue No : " + (currentClue + 1);
        }
        else if (clues[availableClues[currentClue]].text == "")
        {
            clueText.gameObject.SetActive(false);
            clueImage.gameObject.SetActive(true);
            clueImage.texture = clues[availableClues[currentClue]].image;
            clueNo.text = "Clue No : " + (currentClue + 1);
        }
        else
        {
            clueImage.gameObject.SetActive(true);
            clueText.gameObject.SetActive(true);
            clueImage.texture = clues[availableClues[currentClue]].image;
            clueText.text = clues[availableClues[currentClue]].text;
            clueNo.text = "Clue No : " + (currentClue + 1);
        }

    }
    public void ResetClue()
    {
        Debug.Log("Reset Success");
        currentClueDisp = -1;
    }
    //public void SendData()
    //{
    //    gameController.SendData();
    //}
    public void LoadScene()
    {
        gameController.LoadScene();
    }
}
