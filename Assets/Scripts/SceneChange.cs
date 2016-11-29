using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gotoLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void gotoLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void gotoLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void gotoTutorial()
    {
        SceneManager.LoadScene(4);
    }

}
