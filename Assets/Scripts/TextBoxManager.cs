﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text theText;

    public TextAsset textFiles;
    public string[] textLines;

    public int currentLine;
    public int endLine;

    public PlayerController player;
    // Use this for initialization
    void Start()
    {
        textBox.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        if (textFiles != null)
        {
            textLines = (textFiles.text.Split('\n'));
        }
        if (endLine == 0) {
            endLine = textLines.Length - 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.M)) {
            currentLine+=1;
            if (currentLine == endLine) {
                textBox.SetActive(false);
                currentLine = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentLine--;
            if (currentLine < 0)
                currentLine = 0;
        }
    }

    public void showBox()
    {
        textBox.SetActive(true);
    }
 }
