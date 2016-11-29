using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class JournalManager : MonoBehaviour{
    private Dictionary<string, string> entries;
    private Dictionary<string, GameObject> entryButtons;
    private HashSet<string> readEntries;
    private int unreadEntries;
    public Transform entriesLayout;
    public GameObject entryButton;
    public float listDepth;
    public Text information;
    public Text notificationCountText;
    public GameObject notificationDisplay;

    void Start()
    {
        listDepth = -25;
        unreadEntries = 0;
        entries = new Dictionary<string, string>();
        readEntries = new HashSet<string>();
        gameObject.SetActive(false);
        addEntry(Level1Dialogue.OBJECTIVE);
        addEntry(Level1Dialogue.PDA);
        addEntry(Level1Dialogue.VECTOR_INFORMATION);
        addEntry(Level1Dialogue.VECTOR_NOTATION);
        addEntry(Level1Dialogue.MOVEMENT);
        addEntry(Level1Dialogue.FUEL);
        addEntry(Level1Dialogue.BACKTRACKING);
        addEntry(Level1Dialogue.BACKTRACKING_2);
        addEntry(Level1Dialogue.HINTS);
    }

    void addEntry(string[] newEntry)
    {
        entries[newEntry[0]] = newEntry[1];
        GameObject newEntryButton = Instantiate(entryButton) as GameObject;
        newEntryButton.GetComponentInChildren<Text>().text = newEntry[0];
        newEntryButton.transform.SetParent(entriesLayout.transform, false);
        newEntryButton.transform.localPosition = new Vector3(0.0f, 1.0f + listDepth * entries.Count, 0.0f);
        newEntryButton.GetComponent<Button>().onClick.AddListener(() => displayInformation(newEntry[0]));
        //entryButtons[newLabel] = newEntryButton.GetComponent<Button>();
        updateNotificationCount(1);
    }

    public void unlockHint(int level)
    {
        if (level == 1)
        {
            addEntry(Level1Dialogue.HINT1);
        }
        else if (level == 2)
        {
            addEntry(Level1Dialogue.HINT2);
        }
        else if (level == 3)
        {
            addEntry(Level1Dialogue.HINT3);
        }
        else
        {
            addEntry(Level1Dialogue.HINT4);
        }
    }

    void Update()
    {
        //Debug.Log(temp.transform.position);
    }
    
    string getEntry(string label)
    {
        return entries[label];
    }

    public void displayInformation(string entry)
    {
        information.text = entries[entry];
        if (!readEntries.Contains(entry))
        {            
            //entryButtons[entry].GetComponent<Image>().color = Color.gray;
            updateNotificationCount(-1);
            readEntries.Add(entry);
        }
    }

    void updateNotificationCount(int delta)
    {
        unreadEntries += delta;
        notificationCountText.text = unreadEntries.ToString();
        if (unreadEntries == 0)
        {
            notificationDisplay.SetActive(false);
        }
        else 
        {
            notificationDisplay.SetActive(true);
        }
    }


}
