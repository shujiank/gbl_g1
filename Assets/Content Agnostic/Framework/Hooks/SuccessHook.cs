using UnityEngine;
using System.Collections;

public class SuccessHook : Hook
{
    public SuccessHook()
    {
        type = HookType.Success;
    }

    public override string ToString()
    {
        return "Success";
    }
}
