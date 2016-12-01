using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
    private TextBoxManager sword;
    private Content curContent;
    void Start() {
        sword = FindObjectOfType<TextBoxManager>();
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        Debug.Log("collision happened");
        if (this.gameObject.name == "NPC1") {
            curContent = GameInfo.ShearContent;
        }
        if (this.gameObject.name == "NPC2")
        {
            curContent = GameInfo.ProjectionContent;
        }
        if (this.gameObject.name == "NPC3")
        {
            curContent = GameInfo.ReflectionContent;
        }
        if (this.gameObject.name == "NPC4")
        {
            curContent = GameInfo.RotationContent;
        }
        if (this.gameObject.name == "NPC5")
        {
            curContent = GameInfo.StretchContent;
        }
        if (this.gameObject.name == "NPC31")
        {
            curContent = GameInfo.R_SContent;
        }
        if (this.gameObject.name == "NPC32")
        {
            curContent = GameInfo.Stretch_shearContent;
        }
        if (this.gameObject.name == "NPC33")
        {
            curContent = GameInfo.StretchOnLineContent;
        }
        FrameworkCore.setContent(curContent);
        sword.showBox();
    }
}
