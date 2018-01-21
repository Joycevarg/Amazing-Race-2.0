using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

//SCRIPT FOR WEB REQUEST

public class Test : MonoBehaviour {

    GameController gameController;
    public float connectionWaitTime;
    string sendString;
	// Use this for initialization
	void Start () {
        gameController = GameController.gameController;
	}
	
	// Update is called once per frame
	public void Upload ()
    {
       
        StartCoroutine(GetText());
    }
    IEnumerator GetText()
    {
        
        sendString = gameController.outString;
        
        UnityWebRequest www = UnityWebRequest.Get(/*Insert URL in quotes*/""+sendString);
        www.timeout = 3;

        yield return www.SendWebRequest();
        if (Application.internetReachability == NetworkReachability.NotReachable || www.error == "Request timeout")
        {
            Debug.Log("TimeOut");
            gameController.GetComponent<Animator>().SetTrigger("ConnectionFail");
        }
        else
        {
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
                gameController.GetComponent<Animator>().SetTrigger("ConnectionFail");
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                gameController.GetComponent<Animator>().SetTrigger("Connection");
                // Or retrieve results as binary data
                // byte[] results = www.downloadHandler.data;
            }
        }
    }
}
