using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Debug.Log("collision happened");
    }
}
