using UnityEngine;
using System.Collections;

/// <summary>
/// This is the one framework file you should be editing.
/// Everything else from the framework should not need editing.
/// </summary>
public static class GameInfo
{
    // Change to the title of your game.
    public const string gameTitle = "Game Title";

    // Change this to be an object of your child class.
    public static Mechanics mechanics = new NoMechanics();

    // Change each of these to be one of your content objects. If you only have one, leave the second alone for now.
    public static Content contentOne = new NoContent("Placeholder1", "This is the first empty content. Replace it with your own.");
    public static Content contentTwo = new NoContent("Placeholder2", "This is the first empty content. Replace it with your second content.");
}
