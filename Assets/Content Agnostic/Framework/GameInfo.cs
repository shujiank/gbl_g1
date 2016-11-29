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

    public static Content ShearContent = new ShearContent();
    public static Content RotationContent = new RotationContent();
    public static Content ReflectionContent = new ReflectionContent();
    public static Content ProjectionContent = new ProjectContent();
    public static Content StretchContent = new StretchContent();

    public static int gameState = 0;
}
