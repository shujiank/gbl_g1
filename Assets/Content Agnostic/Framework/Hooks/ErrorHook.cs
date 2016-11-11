using UnityEngine;
using System.Collections;

/// <summary>
/// The hook used when encountering an
/// error. Useful for exceptions or other
/// situations that could fail.
/// Note: Not meant for errors on the player's part!
/// </summary>
public class ErrorHook : Hook
{
    public string errorMessage { get; private set; }

    public ErrorHook(string er)
    {
        type = HookType.Error;
        errorMessage = er;
    }

    public override string ToString()
    {
        return "Error: " + errorMessage;
    }
}
