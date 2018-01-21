using UnityEngine;
using UnityEngine.UI;


public class ClueCard : MonoBehaviour
{
    #region ClueType Definition
    public enum ClueType
    {
        TextClue,
        AudioClue,
        GameClue
    };
    #endregion

    GameController gameController;
    public HomeGameController homeGameController;

    public int clueNo;
    

    public ClueType clueType;

    //For text / audio Clues

    public bool visited;
    public int points;      

    public int negative;

    private void Start()
    {
        gameController = GameController.gameController;
    }

    #region Registering Clue for Text/Audio and Checking repetition for Game Clues

    public void RegisterClue()
    {
        if (clueType == ClueType.TextClue)
        {

 //           if (!visited)
            {
                gameController.pointsScored += points;
                gameController.MakeClueAvailable();
                visited = true;
                gameController.Save();
                homeGameController.TargetRefresh();

            }
            //else
            //{
            //    gameController.pointsScored -= negative;
            //}
        }
    }

    #endregion


    public void LoadGame(int GameSceneIndex)
    {
        //int i;
        //for (i = 0; i < gameController.availableClues.Count; i++)
        //{
        //    if (gameController.availableClues[i] == clueNo)
        //    {
        //        break;
        //    }
        //}
        //if (i != gameController.availableClues.Count)
        //{
        //    points -= negative;
        //}

        //if (i == gameController.availableClues.Count)
        {
            gameController.animator.SetTrigger("FadeOut");
            gameController.LoadScene(GameSceneIndex);
        }
    }

}

