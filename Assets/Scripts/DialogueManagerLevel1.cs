using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManagerLevel1 : MonoBehaviour {

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
            Level1Dialogue.GREETINGS[1],
            Level1Dialogue.OBJECTIVE[1],
            Level1Dialogue.PDA[1],
            Level1Dialogue.VECTOR_INFORMATION[1],
            Level1Dialogue.VECTOR_NOTATION[1],
            Level1Dialogue.MOVEMENT[1],
            Level1Dialogue.FUEL[1],
            Level1Dialogue.BACKTRACKING[1],
            Level1Dialogue.HINTS[1],
    };
        StartCoroutine(AnimateText());
    }

    public void HintDisplay(int level)
    {
        gameController.console.inputDevice.SetActive(false);
        gameObject.SetActive(true);
        if (level == 1)
        {
            dialogues = new string[]
            {
                Level1Dialogue.BACKTRACKING_WARNING[1],
                Level1Dialogue.HINT1[1]
            };
            StartCoroutine(AnimateText());
        }
        else if (level == 2)
        {
            dialogues = new string[]
            {
                Level1Dialogue.BACKTRACKING_WARNING[1],
                Level1Dialogue.HINT2[1]
            };
            StartCoroutine(AnimateText());
        }
        else if (level == 3)
        {
            dialogues = new string[]
            {
                Level1Dialogue.BACKTRACKING_WARNING[1],
                Level1Dialogue.HINT3[1]
            };
            StartCoroutine(AnimateText());
        }
        else if (level == 4)
        {
            dialogues = new string[]
            {
                Level1Dialogue.BACKTRACKING_WARNING[1],
                Level1Dialogue.HINT4[1]
            };
            StartCoroutine(AnimateText());
        }
        
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
