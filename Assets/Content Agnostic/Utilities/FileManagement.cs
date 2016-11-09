using UnityEngine;
using System;
using System.IO;
using System.Collections;

/// <summary>
/// This class serves as the single interface for all file writing.
/// The idea is to report all important events so that the game's
/// actions can reviewed later.
/// </summary>
public static class FileManagement
{
    private static bool wasInit = false;
    private static string FILENAME;

    // Get the date to use as the file name.
    public static void init()
    {
        wasInit = true;
        // To ensure files are not overwritten and are easily identifiable, we will name them with the current date and time.
        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        int hour = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;
        int second = DateTime.Now.Second;
        FILENAME = ("Output/" + month + "-" + day + "-" + year + "-" + hour + "-" + minute + "-" + second + ".txt");

        // From: http://stackoverflow.com/questions/2955402/how-do-i-create-directory-if-it-doesnt-exist-to-create-a-file
        // Ensures Output Directory exists
        FileInfo file = new FileInfo(FILENAME);
        file.Directory.Create(); // If it already exists, this call does nothing, so no fear.

        // Test creating files. 
        print("Note: All times listed are in seconds since the start of the game!");
        print("Some times (such as this message) may be the same. This means both happened within the same frame in Unity.");
    }

    // Called to report that a new level was started.
    public static void startLevel(int level)
    {
        print("STARTED NEW LEVEL -> Level " + level);
    }

    // Helper to get timestamp string.
    private static string getTime()
    {
        return "[" + Time.time + "] ";
    }

    // Helper to open and write to the file. Keeping all the possible errors to one point.
    private static void print(string message)
    {
        if (!wasInit)
        {
            init();
        }
        using (StreamWriter file = new StreamWriter(FILENAME, true))
        {
            // The using command here automatically closes and flushes the file.
            file.WriteLine(getTime() + message);
        }
    }

    // Public version to accept any sort of message.
    public static void printToFile(string message)
    {
        print(message);
    }

    /*
     * You will want to write your own functions for common situations that occur with your mechanics.
     * Below is an example template you can use. Also see startLevel above.
     */

    public static void difficultyChange(int diff)
    {
        print("Changed difficulty to: " + diff);
    }

}