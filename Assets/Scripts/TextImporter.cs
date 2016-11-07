using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {
    public TextAsset textFiles;
    public string[] textLines;
    // Use this for initialization
    void Start () {
        if (textFiles != null) {
            textLines = (textFiles.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
