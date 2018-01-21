using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//using Vuforia;

    
public  class GameController : MonoBehaviour
{


    //Dont Destroy on Load Variables
    
    public static GameController gameController;

    //public Test test;

    public string outString;

    //public int NotHour;
    //public int NotMinute;

    //public bool NotSent=false;

    public GameObject masterButton;

    public int playerNo;

    #region Game Level Variables

    public int sendNumber=0;

    //public int blackoutClue = -1;
    public int currentClue=-1;
    public int pointsScored = 0;
    //Clue Class for text and image based clues. For audio/video clues check the children of Persistent Canvas
    [System.Serializable]
    public class Clue
    {
        public Texture image;
        public string text;
        public Clue(Texture image1,string text1)
        {
            image = image1;
            text = text1;
        }
    }

    //public int maxClues;

    public WaitForSeconds loadWait;

    //List of all the Clues available in the game

    public List<Clue> clues;

    //Array of indices of clues which are made available in order

    public List<int> availableClues;


    //Time taken to get to this clue from last one

    public List<int> timeDelay;


    public System.DateTime lastClueRecievedTime;


    //Array of booleans to see if the level is completed

    //public List<bool> levelCompleted;

    //Index to the next level to be completed defaults to level 0 which is the first path chosing level

    //public int currLevel = -1;
    #endregion

    //Fader Animator
    public Animator animator;

    //Persistent Canvas
    public Canvas canvas;

    #region Start and Awake Functions


    private void Awake()
    {
        //Making gamecontroller persist and assigning value to it if it doesnt already have one
        DontDestroyOnLoad(gameObject);

        //Limiting Framerate For reduced battery usage
        Application.targetFrameRate = 30;

        if (GameController.gameController == null)
        {
            GameController.gameController = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
        //Calls the load function and assigns the remaining values
        Load();
        if (availableClues.Count != 0)
        {
            currentClue = availableClues[availableClues.Count - 1];
        }


    }
    private void Start()
    {
        loadWait = new WaitForSeconds(5f);
        //if (currLevel == -1)
        //{
        //    LoadScene(newUserSceneIndex);
        //}
        //else if(currLevel>0)
        //{
        //    LoadScene(currLevel);
        //}

        animator = canvas.GetComponent<Animator>();
        animator.SetTrigger("FadeIn");
        foreach (Clue i in clues)
        {
            i.text=i.text.Replace("\\r\\n", "\n");
        }

    }

    #endregion


    #region Loading a Scene

    public int newUserSceneIndex;

    public void LoadScene(int SceneIndex)
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadSceneAsync(SceneIndex);
    }

    #endregion


    #region Making A Given Clue Available
    public void MakeClueAvailable()
    {
        availableClues.Add((availableClues[availableClues.Count - 1] + 1) % clues.Count);

        currentClue = availableClues[availableClues.Count-1];
        timeDelay[currentClue]=(System.DateTime.Now.Hour-lastClueRecievedTime.Hour)*60*60 + (System.DateTime.Now.Minute-lastClueRecievedTime.Minute)*60 + (System.DateTime.Now.Second - lastClueRecievedTime.Second);

        if (SceneManager.GetActiveScene().buildIndex == 0 && availableClues.Count != 30)
        {
            animator.SetTrigger("ClueNewAppear");
        }

        lastClueRecievedTime = System.DateTime.Now;

        Handheld.Vibrate();

        Save();

        //animator.SetTrigger("ClueAppear");
        //canvas.GetComponent<CluesController>().PrevClue();


        if (availableClues.Count >= gameController.clues.Count)
        {
            gameController.animator.SetTrigger("ARCompleted");
        }
        outString = outString + currentClue.ToString() + '-' + (timeDelay[currentClue] /60).ToString()+ ':' + (timeDelay[currentClue] % 60).ToString() + '/';

        //if ((int)availableClues.Count / 5 > gameController.sendNumber && availableClues.Count != 0 && availableClues.Count != 30)
        //{
        //    sendNumber++;
        //    SendData();
        //}

    }
    #endregion


    #region Saving and Loading Game
    public void Save()
    {
        BinaryFormatter bf;
        bf = new BinaryFormatter();
        SaveData save;
        save = new SaveData
        {
            //currLevel = currLevel
        };
        
        FileStream file = File.Create(Application.persistentDataPath + "/Linfo.dat");

        Debug.Log(Application.persistentDataPath + "/Linfo.dat");

        save.sendNumber = sendNumber;
        //save.levelCompleted = levelCompleted;
        save.availableClues= availableClues;
        save.playerNo = playerNo;
        save.pointsScored = pointsScored;
        save.timeDelay = timeDelay;
        save.lastClueRecievedTime = lastClueRecievedTime;
        save.outString = outString;
        //save.blackoutClue = blackoutClue;

        bf.Serialize(file, save);
        file.Close();
    }

    //Loads the values from save file if it exists or would otherwise initialize the values

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Linfo.dat"))
        {
            BinaryFormatter bf;
            bf = new BinaryFormatter();
            SaveData loaded;
            FileStream file = File.Open(Application.persistentDataPath + "/Linfo.dat", FileMode.Open);
            loaded = (SaveData)bf.Deserialize(file);
            file.Close();

            //Getting values from the loaded file

            //levelCompleted = loaded.levelCompleted;
            //currLevel = loaded.currLevel;
            playerNo = loaded.playerNo;
            pointsScored = loaded.pointsScored;
            availableClues = loaded.availableClues;
            //blackoutClue = loaded.blackoutClue;
            sendNumber = loaded.sendNumber;
            outString = loaded.outString;
            timeDelay = loaded.timeDelay;
            lastClueRecievedTime = loaded.lastClueRecievedTime;
        }
        else
        {
            //for (int i = 0; i < clues.Count; i++)
            //{
            //    levelCompleted.Add(false);
            //}

            for (int i = 0; i < clues.Count; i++)
            {
                timeDelay.Add(-1);
            }
            outString = "";
            lastClueRecievedTime = System.DateTime.Now;
        }
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/Linfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/Linfo.dat");

        }
    }
    public void DeleteSaveRestart()
    {
        if (File.Exists(Application.persistentDataPath + "/Linfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/Linfo.dat");
        }
        Application.Quit();
    }

    [System.Serializable]
    class SaveData
    {
        //public int currLevel;
        public int playerNo;
        //public int blackoutClue;
        public int pointsScored;
        public string outString;
        //public List<bool> levelCompleted;
        public List<int> availableClues;
        public List<int> timeDelay;
        public int sendNumber;
        public System.DateTime lastClueRecievedTime;
    }
    #endregion

    //Debug ONLY

    public void NextClueAvail()
    {
        MakeClueAvailable();
    }

    //public void RemoveBlackout()
    //{
    //    blackoutClue = -1;
    //}

    //public void SendData()
    //{
    //    test.Upload();
    //}
    //public void SendNot()
    //{
    //    if (!NotSent && (System.DateTime.Now.Hour > NotHour || (System.DateTime.Now.Minute > NotMinute && System.DateTime.Now.Hour == NotHour)) && availableClues.Count != 30)
    //    {
    //        NotSent = true;
    //        GetComponent<Animator>().SetTrigger("Notification");
    //    }
    //    else
    //    {
    //        GetComponent<Animator>().SetTrigger("NoNotification");
    //    }
    //}
    public void RemoveNot()
    {
        GetComponent<Animator>().SetTrigger("ClearNot");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

