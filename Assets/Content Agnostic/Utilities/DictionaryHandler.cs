using System.IO;
using UnityEngine;

/// <summary>
/// This class allows you to store multiple dictionaries and
/// change which is active during the game. This was intended
/// for games that teach spelling, but you may find it useful
/// for your content as well. Dictionaries must be a TextAsset.
/// </summary>

public class DictionaryHandler : MonoBehaviour
{
    public TextAsset[] dicts; // You cannot modify statics in the inspector.
    private static TextAsset[] dictionaries; // An array of the dictionary TextAsset files.
    private static int activeDict = 0; // Index of the active dictionary.
    private static string[] dictionary; // The actual loaded words from the dictionary.
    private static int dictionaryLength; // The length (number of words) in the loaded dictionary.

    void Start()
    {
        dictionaries = dicts;
    }

    // For displaying the list of options in game.
    public string[] getDictNames()
    {
        string[] names = new string[dictionaries.Length];

        for (int i = 0; i < dictionaries.Length; i++)
        {
            names[i] = dictionaries[i].name;
        }

        return names;
    }

    // Call this to get the dictionary itself.
    public static TextAsset getActiveDict()
    {
        return dictionaries[activeDict];
    }

    // This will load the current dictionary into the string array so you can access individual words.
    public static void LoadDictionary()
    {
        if (dictionaries != null)
        {
            StringReader sr = new StringReader(dictionaries[activeDict].text);
            dictionaryLength = 0;
            string substring = sr.ReadLine();
            while (substring != null)
            {
                dictionaryLength++;
                substring = sr.ReadLine();
            }
            dictionary = new string[dictionaryLength];
            int i = 0;
            sr = new StringReader(dictionaries[activeDict].text);
            substring = sr.ReadLine();
            while (substring != null)
            {
                substring = substring.ToUpper();
                dictionary[i++] = substring;
                substring = sr.ReadLine();
            }
        }
    }

    // These two functions are for GUI purposes.

    public static void setActiveDict(int i)
    {
        activeDict = i;
    }

    public static string getActiveDictName()
    {
        return dictionaries[activeDict].name;
    }
}