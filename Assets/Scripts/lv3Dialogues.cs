using UnityEngine;
using System.Collections;

public class lv3Dialog : MonoBehaviour
{
    private lv3TextBoxManager sword;
    private Content curContent;
    void Start()
    {
        sword = FindObjectOfType<lv3TextBoxManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("collision happened");
        if (this.gameObject.name == "NPC1")
        {
            curContent = GameInfo.R_SContent;
        }
        if (this.gameObject.name == "NPC2")
        {
            curContent = GameInfo.Stretch_shearContent;
        }
        if (this.gameObject.name == "NPC3")
        {
            curContent = GameInfo.StretchOnLineContent;
        }
        if (this.gameObject.name == "NPC4")
        {
            curContent = GameInfo.RotationContent;
        }
        FrameworkCore.setContent(curContent);
        sword.showBox();
    }
}
