using UnityEngine;
using System.Collections;

public class TriggerSuccess : MonoBehaviour
{
    public GameObject successWindow;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        successWindow.SetActive(true);
    }
}
