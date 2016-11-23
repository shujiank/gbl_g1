using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class JournalManager : MonoBehaviour{
    private Dictionary<string, string> entries;
    public Transform entriesLayout;
    public GameObject entryButton;
    public float listDepth;
    public Text information;

    //GameObject temp;

    void Start()
    {
        listDepth = -25;
        entries = new Dictionary<string, string>();
        gameObject.SetActive(false);
        addEntry("Vector Information", "In mathematics, physics, and engineering, a Euclidean vector is a geometric object that has magnitude (or length) and direction. Vectors can be added to other vectors according to vector algebra.");
        addEntry("Abhimanyu", "Jingle bells jingle bells jingle all the way=");
        addEntry("Abhimanyu2", "Jingle bells jingle bells jingle all the way-");
        addEntry("Abhimanyu3", "Jingle bells jingle bells jingle all the way0");
        addEntry("Abhimanyu4", "Jingle bells jingle bells jingle all the way9");
        addEntry("Abhimanyu5", "Jingle bells jingle bells jingle all the way8");
        addEntry("Abhimanyu6", "Jingle bells jingle bells jingle all the way7");
    }

    void addEntry(string newLabel, string newEntry)
    {
        entries[newLabel] = newEntry;
        GameObject newEntryButton = Instantiate(entryButton) as GameObject;
        newEntryButton.GetComponentInChildren<Text>().text = newLabel;
        newEntryButton.transform.SetParent(entriesLayout.transform, false);
        newEntryButton.transform.localPosition = new Vector3(0.0f, 0.0f + listDepth * entries.Count, 0.0f);
        newEntryButton.GetComponent<Button>().onClick.AddListener(() => displayInformation(newLabel));
        //temp = newEntryButton;

    }

    void Update()
    {
        //Debug.Log(temp.transform.position);
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

    public void displayInformation(string entry)
    {
        information.text = entries[entry];
    }


}
