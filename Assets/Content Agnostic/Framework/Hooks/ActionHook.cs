using UnityEngine;
using System.Collections;

/// <summary>
/// The hook used when you need to pass
/// actions to the content class or its derivatives
/// </summary>
public class ActionHook : Hook
{
    public string action { get; private set; }

    public ActionHook(string ac)
    {
        type = HookType.Action;
        action = ac;
    }

    public override string ToString()
    {
        return "Action performed: " + action;
    }
}