using UnityEngine;
using System.Collections;

public class MenuManger : MonoBehaviour {

    public Menu CurrentMenu;
    public void Start() {
        ShowMenu(CurrentMenu);
    }

    public void ShowMenu(Menu menu) {
        if (CurrentMenu != null) {
            CurrentMenu.IsOpen = false;
            CurrentMenu = menu;
            CurrentMenu.IsOpen = true;
        }
    }

    public void LoadLevel()
    {
        Application.LoadLevel("level1");
    }

    public void quit()
    {
       
        Application.Quit();

    }
}
