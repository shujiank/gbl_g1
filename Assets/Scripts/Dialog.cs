using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
    private TextBoxManager sword;
    void Start() {
        sword = FindObjectOfType<TextBoxManager>();
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("collision happened");
        sword.showBox();
    }
}
