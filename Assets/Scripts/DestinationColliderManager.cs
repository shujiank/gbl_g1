using System;
using UnityEngine;
using System.Collections;

public class DestinationColliderManager : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        GameObject gameworldObject = GameObject.Find("Gameworld");
        if (gameworldObject != null)
        {
            gameController = gameworldObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("DESTINATION COLLIDER TRIGGERED!!!");
        other.gameObject.SetActive(false);
        gameController.MissionSuccessful();
    }
}

