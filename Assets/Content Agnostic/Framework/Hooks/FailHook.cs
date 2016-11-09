using UnityEngine;
using System.Collections;

public class FailHook : Hook
{
    public FailHook()
    {
        type = HookType.Fail;
    }

    public override string ToString()
    {
        return "Fail";
    }
}
