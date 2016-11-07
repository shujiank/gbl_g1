using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text theText;
    public Image theImage;

    public TextAsset textFiles;
    public string[] textLines;
    public Sprite[] avatarSprites;

    public int currentLine;
    public int endLine;

    public PlayerController player;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;
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
        //dtw.typeWriter(textLines[currentLine]);
        //theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.M)) {

            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine == endLine)
                {
                    textBox.SetActive(false);
                    currentLine = 0;
                }
                else {
                    theImage.sprite = avatarSprites[currentLine];
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping) {
                cancelTyping = true;
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
        theImage.sprite = avatarSprites[currentLine];
        StartCoroutine(TextScroll(textLines[currentLine]));
    }
 }
