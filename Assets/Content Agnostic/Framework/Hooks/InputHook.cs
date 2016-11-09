using UnityEngine;
using System.Collections;

/// <summary>
/// This is the hook for sending player input
/// as a string.
/// </summary>
public class InputHook : Hook
{
    public string message { get; private set; }

    public InputHook(string i)
    {
        type = HookType.Input;
        message = i;
    }

    public override string ToString()
    {
        return "Input: " + message;
    }
}
