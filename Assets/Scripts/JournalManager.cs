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
        addEntry("Example1", "Jingle bells jingle bells jingle all the way1");
        addEntry("Example2", "Jingle bells jingle bells jingle all the way2");
        addEntry("Example3", "Jingle bells jingle bells jingle all the way3");
        addEntry("Example4", "Jingle bells jingle bells jingle all the way4");
        addEntry("Example5", "Jingle bells jingle bells jingle all the way5");
        addEntry("Example6", "Jingle bells jingle bells jingle all the way6");
        addEntry("Example7", "Jingle bells jingle bells jingle all the way7");
        addEntry("Example8", "Jingle bells jingle bells jingle all the way8");
        addEntry("Example9", "Jingle bells jingle bells jingle all the way9");
        addEntry("Example10", "Jingle bells jingle bells jingle all the way10");
        addEntry("Example11", "Jingle bells jingle bells jingle all the way11");
        addEntry("Example12", "Jingle bells jingle bells jingle all the way12");
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
            buttonLabel.text = "open journal";
        }
        else
        {
            gameObject.SetActive(true);
            buttonLabel.text = "close journal";
        }
    }

    public void displayInformation(string entry)
    {
        information.text = entries[entry];
    }


}
