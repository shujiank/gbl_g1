using UnityEngine;
using System.Collections;

/// <summary>
/// Do NOT modify this class! Hooks are the
/// way that mechanics pass generic information
/// to the content. Each individual content 
/// component will accept different types of
/// Hooks to accept only information that is
/// needed for that particular content domain.
/// If you want to add a new type of hook, add
/// it to the HookType enum, and inherit this
/// class. Make sure to override ToString!
/// </summary>
public class Hook
{
    public HookType type { get; protected set; }

    public Hook()
    {
        type = HookType.Error;
    }

    public Hook(HookType myType)
    {
        type = myType;
    }

    // Override this in custom hooks.
    public override string ToString()
    {
        return "Generic Hook";
    }
}
