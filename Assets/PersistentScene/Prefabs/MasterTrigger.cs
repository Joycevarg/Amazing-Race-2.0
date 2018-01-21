using UnityEngine;
using UnityEngine.UI;

public class MasterTrigger : MonoBehaviour
{

    GameObject button;
    public Canvas canvas;
    GameController gameController;
    public MeshRenderer mesh;
    public void Start()
    {
        gameController = GameController.gameController;
        button = gameController.masterButton;
    }

    private void Update()
    {
        if(canvas.enabled)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
