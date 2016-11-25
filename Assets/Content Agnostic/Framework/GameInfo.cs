﻿using UnityEngine;
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
}
