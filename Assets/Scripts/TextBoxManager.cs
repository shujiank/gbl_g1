using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    // show transformation after dialog ends
    public GameObject matrixButton;
    public GameObject transformationPlane;

    public GameObject textBox;
    public Text theText;
    public Image theImage;
    public GameObject[] NPCs;
    public GameObject imageBox;
    public Sprite img;
    public TextAsset textFiles;
    public string[] textLines;
    public Sprite[] avatarSprites;

    public int currentLine;
    public int endLine;

    public int questionLine;
    public Sprite mySecondImage;
    public PlayerController player;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;
    Image myImageComponent;
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < 6; i++) {
            NPCs[i].SetActive(false);
        }
        textBox.SetActive(false);
        imageBox.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        //avatarSprites = FrameworkCore.currentContent.getPortrait();
        /*
        textFiles = (TextAsset)Resources.Load("dialog.txt", typeof(TextAsset));
        if (textFiles != null)
        {
            textLines = (textFiles.text.Split('\n'));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //dtw.typeWriter(textLines[currentLine]);
        //theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.M)) {

            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine == endLine)
                {
                    textBox.SetActive(false);
                    imageBox.SetActive(false);
                    currentLine = 0;

                    // show transformation
                    openTransformPlane();
                }
                else {
                    theImage.sprite = avatarSprites[currentLine];
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping) {
                cancelTyping = true;
            }
            if (currentLine == questionLine)
            {
                imageBox.SetActive(true);
                GameObject.Find("ImageX").GetComponent<Image>().sprite = img;
            }
            /*if (currentLine == endLine - 1)
            {
                imageBox.SetActive(true);
                GameObject.Find("ImageX").GetComponent<Image>().sprite = mySecondImage;
            }*/
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!isTyping)
            {
                currentLine--;
                if (currentLine < 0)
                {
                    currentLine = 0;
                }
                else
                {
                    theImage.sprite = avatarSprites[currentLine];
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }


    private IEnumerator TextScroll(string s)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < s.Length - 1)) {
            theText.text += s[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }

        theText.text = s;
        isTyping = false;
        cancelTyping = false;
    }

    public void showBox()
    {
        textBox.SetActive(true);
        textLines = FrameworkCore.currentContent.getContent();
        avatarSprites = FrameworkCore.currentContent.getPortrait();
        img = FrameworkCore.currentContent.getQuestion();
        theImage.sprite = avatarSprites[currentLine];
        StartCoroutine(TextScroll(textLines[currentLine]));
        endLine = textLines.Length - 1;
    }

    public void closeTransformPlane()
    {
        matrixButton.SetActive(false);
        transformationPlane.SetActive(false);
        NPCs[GameInfo.gameState].SetActive(false);
        GameInfo.gameState += 1;
        NPCs[GameInfo.gameState].SetActive(true);
    }

    public void openTransformPlane()
    {
        matrixButton.SetActive(true);
        transformationPlane.SetActive(true);
    }

}
