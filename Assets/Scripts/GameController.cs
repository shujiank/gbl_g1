using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Console
{
    public GameObject gameOverScreen;
    public GameObject journal;
    public GameObject PDA;
    public GameObject journalButton;
    public GameObject pdaButton;
    public GameObject dialogueBox;
    public GameObject missionSuccessfulScreen;
    public GameObject undoButton;
    public GameObject inputDevice;
}


public class GameController : MonoBehaviour {
    public Console console;
    public GameObject player;
    public Text statsText;
    public GameObject destinationPrefab;

    private PlayerController playerController;

    void Start() {
        console.missionSuccessfulScreen.SetActive(false);
        console.gameOverScreen.SetActive(false);
        console.inputDevice.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        Vector3 spawnLocation = new Vector3(playerController.final_destination.x + 0.5f, 0.4f, playerController.final_destination.z + 0.5f);
        Instantiate(destinationPrefab, spawnLocation, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggleJournal()
    {
        if (!console.dialogueBox.activeSelf)
        {
            Text buttonLabel = console.journalButton.GetComponentInChildren<Text>();
            if (console.journal.activeSelf)
            {
                console.journal.SetActive(false);
                buttonLabel.text = "open journal";
            }
            else
            {
                console.PDA.SetActive(false);
                console.journal.SetActive(true);
                buttonLabel.text = "close journal";
            }
        }
    }

    public void togglePDA()
    {
        if (!console.dialogueBox.activeSelf)
        {
            Text buttonLabel = console.pdaButton.GetComponentInChildren<Text>();
            if (console.PDA.activeSelf)
            {
                console.PDA.SetActive(false);
                buttonLabel.text = "open pda";
            }
            else
            {
                console.journal.SetActive(false);
                console.PDA.SetActive(true);
                buttonLabel.text = "close pda";
            }
        }
    }

    public void GameOver()
    {
        disableConsoleElements();
        console.gameOverScreen.SetActive(true);
    }

    public void MissionSuccessful()
    {
        disableConsoleElements();
        Dictionary<string, float> finalStats = playerController.getFinalStats();
        float totalMoves = finalStats["number of moves"];
        float totalTime = finalStats["time taken"];
        float totalHints = finalStats["number of hints used"];
        float optimalMoveCount = finalStats["optimal move count"];
        float finalScore = (5000 * (2 / totalMoves)) - (((totalTime - 2) / 2) * 100) - (totalHints * 100);
        statsText.text = "final score : " + finalScore.ToString() + "\nnumber of moves : " + totalMoves.ToString() + "\nnumber of hints used : " +
            totalHints.ToString() + "\ntime taken : " + totalTime.ToString();
        console.missionSuccessfulScreen.SetActive(true);
    }

    public void returnToMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void restart()
    {
        Application.LoadLevel("level1");
    }


    void disableConsoleElements()
    {
        console.journal.SetActive(false);
        console.PDA.SetActive(false);
        console.journalButton.SetActive(false);
        console.pdaButton.SetActive(false);
        console.undoButton.SetActive(false);
        console.inputDevice.SetActive(false);
    }
}
