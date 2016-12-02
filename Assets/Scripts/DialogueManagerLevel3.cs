using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManagerLevel3 : MonoBehaviour
{

    public Text textBox;
    public string[] dialogues;
    int currentlyDisplayingText = 0;
    public GameObject gameWorld;

    private GameController gameController;


    public void Start()
    {
        gameController = gameWorld.GetComponent<GameController>();
        dialogues = new string[]
        {

       };
        
    }

    public void HintDisplay(int level)
    {
        

    }

    public void BoundaryWarning()
    {
        gameController.console.inputDevice.SetActive(false);
        gameObject.SetActive(true);

        dialogues = new string[]
        {
            Level1Dialogue.BOUNDARY_WARNING[1]
        };
        StartCoroutine(AnimateText());
    }


    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        if (currentlyDisplayingText >= dialogues.Length)
        {
            currentlyDisplayingText = 0;
            gameObject.SetActive(false);
            gameController.console.inputDevice.SetActive(true);
            return;
        }

        StartCoroutine(AnimateText());
    }

    public void SkipToEnd()
    {
        StopAllCoroutines();
        currentlyDisplayingText = 0;
        gameObject.SetActive(false);
        gameController.console.inputDevice.SetActive(true);
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < (dialogues[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = dialogues[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.015f);
        }
    }
}
