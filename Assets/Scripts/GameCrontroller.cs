using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCrontroller : MonoBehaviour {

    public GameObject journal;

    void Start()
    {

    }
	
    public void levelComplete()
    {
        Debug.Log("LEVEL COMPLETE");
    }

    public void gameOver()
    {
        Debug.Log("GAME OVER");
    }
}
