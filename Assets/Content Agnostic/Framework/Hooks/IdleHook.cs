using UnityEngine;
using System.Collections;

/// <summary>
/// Hook for when the player is idle for
/// an extended period of time. i.e. They
/// are confused.
/// </summary>
public class IdleHook : Hook
{
    // The amount of time they were idle.
    public float duration { get; private set; }

    public IdleHook(float d)
    {
        type = HookType.Idle;
        duration = d;
    }

    public override string ToString()
    {
        return "Idle: " + duration;
    }
}
