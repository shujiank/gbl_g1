using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    // show transformation after dialog ends
    public GameObject matrixButton;
    public GameObject transformationPlane;
    public int levelParameters;

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
    private int endLine;

    public int questionLine;
    public Sprite mySecondImage;
    public PlayerMovementLevel2 player;

    private bool isTyping = false;
    private bool cancelTyping = false;
    private bool allowed;
    public float typeSpeed;
    Image myImageComponent;
    // Use this for initialization
    void Start()
    {
        for (int i = 1; i < NPCs.Length; i++)
        {
            NPCs[i].SetActive(false);
        }
        textBox.SetActive(false);
        imageBox.SetActive(false);
        player = FindObjectOfType<PlayerMovementLevel2>();
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
        if (allowed)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {

                if (!isTyping)
                {
                    currentLine += 1;
                    if (currentLine == endLine)
                    {
                        imageBox.SetActive(false);
                        currentLine = 0;

                        // show transformation
                        openTransformPlane();
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
                if (currentLine == questionLine)
                {
                    imageBox.SetActive(true);
                    GameObject.Find("ImageX").GetComponent<Image>().sprite = img;
                }
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
    }


    private IEnumerator TextScroll(string s)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < s.Length - 1))
        {
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
        //player = FindObjectOfType<PlayerMovementLevel2>();
        textBox.SetActive(true);
        textLines = FrameworkCore.currentContent.getContent();
        avatarSprites = FrameworkCore.currentContent.getPortrait();
        img = FrameworkCore.currentContent.getQuestion();
        theImage.sprite = avatarSprites[currentLine];
        StartCoroutine(TextScroll(textLines[currentLine]));
        if (levelParameters == 2)
        {
            player.canMove = false;

        }
        //player.canMove = false;
        endLine = textLines.Length;
        allowed = true;
    }

    public void closeTransformPlane()
    {
        if (levelParameters == 2)
        {
            player.canMove = true;
        }
        textBox.SetActive(false);
        matrixButton.SetActive(false);
        currentLine = 0;
        transformationPlane.SetActive(false);
        NPCs[GameInfo.gameState].SetActive(false);
        GameInfo.gameState += 1;
        NPCs[GameInfo.gameState].SetActive(true);
        return;

    }

    public void openTransformPlane()
    {
        allowed = false;
        theText.text = textLines[textLines.Length - 1];
        matrixButton.SetActive(true);
        transformationPlane.SetActive(true);
    }

}
