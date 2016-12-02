using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class ConsoleL3
{
    public GameObject gameOverScreen;
    public GameObject journal;
    public GameObject PDA;
    public GameObject journalButton;
    public GameObject pdaButton;
    public GameObject dialogueBox;
    public GameObject missionSuccessfulScreen;
}


public class GameControllerL3 : MonoBehaviour
{
    public ConsoleL3 console;
    public GameObject player;
    public Text statsText;
    public GameObject destinationPrefab;

    private PlayerController playerController;

    void Start()
    {
        console.missionSuccessfulScreen.SetActive(false);
        console.gameOverScreen.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        Vector3 spawnLocation = new Vector3(playerController.final_destination.x + 0.5f, 0.4f, playerController.final_destination.z + 0.5f);
        Instantiate(destinationPrefab, spawnLocation, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

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
        float totalUndos = finalStats["number of undos used"];
        float optimalMoveCount = finalStats["optimal move count"];
        float finalScore = (5000 * (2 / totalMoves)) - (totalTime * 100) - (totalUndos * 800);
        statsText.text = "final score : " + finalScore.ToString() + " / 5000\nnumber of moves : " + totalMoves.ToString() + "\nnumber of undos used : " +
            totalUndos.ToString() + "\ntime taken : " + totalTime.ToString() + " min";
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

    public void nextLevel()
    {
        Application.LoadLevel("level2");
    }


    void disableConsoleElements()
    {
        console.journal.SetActive(false);
        console.PDA.SetActive(false);
        console.journalButton.SetActive(false);
        console.pdaButton.SetActive(false);
    }
}
