using UnityEngine;
using System.Collections;

/// <summary>
/// Do NOT modify this class!
/// This is the base class for all
/// mechanics components. Your game
/// should build one mechanics component
/// that inherits this one.
/// 
/// Given the way mechanics are designed
/// and developed, you will almost certainly
/// have many scripts that make up your
/// mechanics. This is perfectly fine.
/// The child class of this that you build
/// will be the way your mechanics interface
/// with the content component.
/// </summary>
public abstract class Mechanics
{
    public Mechanics()
    {
        return;
    }

    /*
     * These are the handlers for all the standard
     * hook types. These are not virtual because
     * they should not need to be changed. Write
     * your own handlers for any custom hooks you
     * write.
     */

    protected void passHook(Hook hook)
    {
        FrameworkCore.currentContent.acceptHook(hook);
    }

    public void sendHook(HookType type)
    {
        passHook(new Hook(type));
    }

    public void sendHook(HookType type, string message)
    {
        Hook temp;
        switch (type)
        {
            case HookType.Action:
                temp = new ActionHook(message);
                break;
            case HookType.Error:
                temp = new ErrorHook(message);
                break;
            case HookType.Input:
                temp = new InputHook(message);
                break;
            default:
                temp = new Hook();
                Debug.LogError("sendHook with string parameter could not determine hook type!");
                break;
        }
        passHook(temp);
    }

    public void sendHook(Analytics data)
    {
        passHook(new AnalyticsHook(data));
    }
    public void sendHook(float fl)
    {
        passHook(new IdleHook(fl));
    }

    public void sendHook(Task task)
    {
        passHook(new TaskHook(task));
    }

    public void sendHook(GameObject go)
    {
        passHook(new GameObjectHook(go));
    }
}