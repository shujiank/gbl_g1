using UnityEngine;
using System.Collections;

public class SuccessWindow : MonoBehaviour
{
    public GameObject successWindow;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        successWindow.SetActive(true);
    }
}
