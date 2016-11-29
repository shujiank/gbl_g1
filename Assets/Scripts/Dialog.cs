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
        FrameworkCore.setContent(curContent);
        sword.showBox();
    }
}
