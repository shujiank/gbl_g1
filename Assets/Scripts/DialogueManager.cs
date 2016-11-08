using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject textObj;
    public Text dialogueText;
    public Text problemDes;
    private string[] dialogueContent;
    private int currentLine;
    public static Content test = new TestContent();

    // Use this for initialization
    void Start () {
        FrameworkCore.setContent(test);
        dialogueContent = FrameworkCore.currentContent.getContent();
        currentLine = 1;
        dialogueText.text = dialogueContent[currentLine];
        problemDes.text = dialogueContent[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            currentLine += 1;
            if (currentLine < dialogueContent.Length)
            {
                dialogueText.text = dialogueContent[currentLine];
            }
            else {
                textObj.SetActive(false);
            }
        }
	}
}
