using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class JournalManager : MonoBehaviour{
    Dictionary<string, string> entries;

    void Start()
    {
        gameObject.SetActive(false);
        entries["Vector Information"] = "In mathematics, physics, and engineering, a Euclidean vector is a geometric object that has magnitude (or length) and direction. Vectors can be added to other vectors according to vector algebra.";
    }

    void addEntry(string newLabel, string newEntry)
    {
        entries[newLabel] = newEntry;
    }
    
    string getEntry(string label)
    {
        return entries[label];
    }

    public void toggleDisplay()
    {
        Text buttonLabel = GameObject.Find("Journal Button").GetComponentInChildren<Text>();
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            buttonLabel.text = "OPEN JOURNAL";
        }
        else
        {
            gameObject.SetActive(true);
            buttonLabel.text = "CLOSE JOURNAL";
        }
    }


}
