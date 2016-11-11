using UnityEngine;
using System.Collections;

/// <summary>
/// The hook used when you need to pass
/// a gameObject (ex clicked upon by user)
/// </summary>
public class GameObjectHook : Hook
{
    public  GameObject target { get; private set; }

    public GameObjectHook(GameObject go)
    {
        type = HookType.Gameobject;
        target = go;
    }

    public override string ToString()
    {
        return "Target gameobject: " + target.name;
    }
}