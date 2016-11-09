using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles the GUI aspect of the main menu.
/// You should not need to modify this class!
/// Instead, any changes you need to make
/// should be achieveable through the editor. For
/// example, to change the look, change the GameObjects
/// directly in the editor.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public Text title;
    public Text domain;
    public Text description;
    public Text contentOneText;
    public Text contentTwoText;

    private int pulseDelay = 0;
    private const int DELAY = 15;

    private Content contentOne;
    private Content contentTwo;

    // Use this for initialization
    void Start()
    {
        // Change these in ContentList to each be one of your own content objects!
        contentOne = GameInfo.contentOne;
        contentTwo = GameInfo.contentTwo;

        // Change this to the title of your game in ContentList.
        title.text = GameInfo.gameTitle;

        // Set as a blank before the player selects one.
        FrameworkCore.setContent(new NoContent());
        updateDisplay();
        FileManagement.init(); // Create the dump file to mark the start of the game.
    }

    // Update is called once per frame
    void Update()
    {
        if(pulseDelay > 0)
        {
            pulseDelay--;
            description.color = Color.red;
        }
        else
        {
            description.color = Color.white;
        }
    }

    // Updates various pieces of text on the screen.
    private void updateDisplay()
    {
        domain.text = FrameworkCore.currentContent.name;
        description.text = FrameworkCore.currentContent.description;
    }

    // Button functions
    public void hitContentOne()
    {
        FrameworkCore.setContent(contentOne);
        updateDisplay();
    }

    public void hitContentTwo()
    {
        FrameworkCore.setContent(contentTwo);
        updateDisplay();
    }

    public void hitStart()
    {
        if(FrameworkCore.currentContent.GetType() == typeof(NoContent))
        {
            pulseDelay = DELAY;
        }
        else
        {
            // Loads the next scene in the build order. Main menu should be 0, first level should be 1, etc.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void hitQuit()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
