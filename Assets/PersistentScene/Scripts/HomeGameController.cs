using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HomeGameController : MonoBehaviour {

    GameController gameController;
    //int playerNo;
    public int currentClue;
    public int blackoutStartClue = -1;

    //public bool notSent;
    //public bool finalSent;

    //public int EndHour;
    //public int EndMinute;

    //public int NotHour;
    //public int NotMinute;

    public List<GameObject> Targets;
    List<int> availableClues;

    #region Blackout Variables

    bool loading = false;

    //public Text blackoutText;
    //public int blackOutStartMinute;
    //public int blackOutStartHour;
    //public int blackOutEndMinute;
    //public int blackOutEndHour;
    //public GameObject blackOutScreen;
    //public bool blackedOut = false;

    #endregion

    // Use this for initialization
    void Start ()
    {
        gameController = GameController.gameController;
        //   playerNo = gameController.playerNo;
        //notSent = gameController.NotSent;
        availableClues = gameController.availableClues;

        for (int i = 0; i < availableClues.Count; i++)
        {
            int j;

            for (j = 0; j < Targets.Count; j++)
            {
                if (Targets[j].GetComponent<ClueCard>().clueNo == availableClues[i])
                {
                    Targets[j].GetComponent<ClueCard>().visited = true;
                    break;
                }
            }
            if (j == Targets.Count)
            {
                break;
            }
        }
        if (availableClues.Count != 0)
        {
            currentClue = availableClues[availableClues.Count - 1];
        }
        if (currentClue != -1)
        {
            DeactivateAllTargets();
            ActivateTarget(currentClue);
        }

        //if ((int)availableClues.Count / 5 > gameController.sendNumber && availableClues.Count != 0 && availableClues.Count != 30)
        //{
        //    gameController.sendNumber++;
        //    gameController.SendData();
        //}


        if (availableClues.Count >= gameController.clues.Count)
        {
            gameController.animator.SetTrigger("ARCompleted");
        }
        //blackoutStartClue = gameController.blackoutClue;

        if (availableClues.Count != 0)
        {
            gameController.animator.SetTrigger("ClueNewAppear");
        }


    }


    public void MakeClueAvailable()
    {
        gameController.MakeClueAvailable();
    }

    #region Update Function

    private void Update()
    {
        if (availableClues.Count==0 && !loading)
        {
            loading = true;
            gameController.LoadScene(gameController.newUserSceneIndex);
        }

        currentClue = gameController.currentClue;

        //if(System.DateTime.Now.Hour >EndHour ||( System.DateTime.Now.Minute >EndMinute && System.DateTime.Now.Hour==EndHour))
        //{
        //    DeactivateAllTargets();
        //    if (!finalSent)
        //    {
        //        finalSent = true;
        //        gameController.SendData();
        //        gameController.animator.SetTrigger("ARCompleted");
        //    }
        //}
        //if (!notSent && availableClues.Count != 30 && (System.DateTime.Now.Hour > NotHour || (System.DateTime.Now.Minute > NotMinute && System.DateTime.Now.Hour == NotHour)))
        //{
        //    notSent = true;
        //    gameController.SendData();
        //}

        //if (!blackedOut)
        //{
            
        //    if (System.DateTime.Now.Hour == blackOutStartHour)
        //    {
        //        if (System.DateTime.Now.Minute >= blackOutStartMinute && System.DateTime.Now.Minute < blackOutEndMinute)
        //        {
        //            if (blackoutStartClue == -1 && blackoutStartClue!=currentClue)
        //            {
        //                blackoutStartClue = currentClue;
        //                gameController.blackoutClue = currentClue;
        //                gameController.Save();
        //            }
        //            else if (blackoutStartClue != currentClue)
        //            {
        //                blackOutScreen.SetActive(true);
        //                blackedOut = true;
        //            }
        //        }
        //    }

        //}
        //else
        //{
        //    blackoutText.text = "It's Lunch Break right now \n"+((blackOutEndHour- System.DateTime.Now.Hour) * 60 + (blackOutEndMinute- System.DateTime.Now.Minute)).ToString() + " minutes to go ";

        //    if (System.DateTime.Now.Hour >= blackOutEndHour && System.DateTime.Now.Minute > blackOutEndMinute)
        //    {
        //        blackOutScreen.SetActive(false);
        //        blackedOut = false;
        //    }
        //}
    }
    #endregion

    #region Target Control

    public void DeactivateAllTargets()
    {
        int l = Targets.Count;
        for (int i = 0; i < l; i++)
        {
            Targets[i].SetActive(false);
        }
    }

    public void ActivateTarget(int targetIndex)
    {
        Targets[targetIndex].SetActive(true);
    }

    public void TargetRefresh()
    {
        if (availableClues.Count != -1)
        {
            DeactivateAllTargets();
            ActivateTarget(gameController.currentClue);
        }
    }



    #endregion

}
