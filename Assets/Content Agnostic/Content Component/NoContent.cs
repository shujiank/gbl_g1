using UnityEngine;
using System.Collections;

/// <summary>
/// This class represents no knowledge domain.
/// This is the default selected by the main menu
/// before the player has made a choice.
/// </summary>
public class NoContent : Content
{

    public NoContent()
    {
        name = "None";
        description = "No topic is selected!";
    }

    public NoContent(string n, string d) : base(n, d)
    {
        return; // Empty, just invokes base constructor.
    }
}
