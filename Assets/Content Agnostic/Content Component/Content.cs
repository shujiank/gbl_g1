using UnityEngine;
using System.Collections;

/// <summary>
/// This class represents a content domain or subject
/// to be taught by the game. DO NOT modify this class!
/// Instead, your individual content domains should
/// inherit from this class.
/// </summary>
public abstract class Content
{
    // These are both for display purposes.
    public string name { get; protected set; }
    public string description { get; protected set; }

    /// <summary>
    /// This determines whether or not the last action
    /// that the player attempted was valid ro not. This 
    /// will be updated by your hook handlers and the
    /// get method for it will be called by your mechanics
    /// as needed. The idea is, the player attempts to solve
    /// the problem, you get the hook for it and determine if
    /// they solved it correctly or not and store that in
    /// this variable, which the mechanics then checks to see
    /// if the player actually solved the problem or not.
    /// </summary>
    protected bool lastActionValid = false;

    // Default constructor
    public Content()
    {
        name = "";
        description = "";
    }

    // Actual constructor, you probably want to override the default and use fixed values.
    public Content(string n, string d)
    {
        name = n;
        description = d;
    }

    public virtual string[] getContent()
    {
        return new string[1];
    }

    public virtual Sprite[] getPortrait()
    {
        return new Sprite[1];
    }



    /// <summary>
    /// This returns a char representation of something to
    /// be shown to the player that depends on the active
    /// content (ie. a letter or a digit). Override this
    /// with one that returns the proper thing in your
    /// class.
    /// </summary>
    /// <returns>A single character as relevant to this content.</returns>
    public virtual char getItem()
    {
        return '!';
    }


    /// <summary>
    /// Here is where your mechanics can "ask" the content
    /// if the player succeeded or not.
    /// </summary>
    /// <returns>True if the player's last action was correct.</returns>
    public bool wasLastActionValid()
    {
        return lastActionValid;
    }

    // Do not override this! See next method customHook.
    public void acceptHook(Hook hook)
    {
        StudentModel.acceptHook(hook);
        switch (hook.type)
        {
            case HookType.Action:
                actionHook((ActionHook)hook);
                break;
            case HookType.Analytics:
                analyticsHook((AnalyticsHook)hook);
                break;
            case HookType.Error:
                errorHook((ErrorHook)hook);
                break;
            case HookType.Fail:
                failHook((FailHook)hook);
                break;
            case HookType.Gameobject:
                gameObjectHook((GameObjectHook)hook);
                break;
            case HookType.Idle:
                idleHook((IdleHook)hook);
                break;
            case HookType.Input:
                inputHook((InputHook)hook);
                break;
            case HookType.Success:
                successHook((SuccessHook)hook);
                break;
            case HookType.Task:
                taskHook((TaskHook)hook);
                break;
            default:
                customHook(hook);
                break;
        }
    }

    /// <summary>
    /// If you make a new type of hook, you will need
    /// to override this function. You will want to add
    /// your new type to the switch in here. Do not change
    /// acceptHook above! This way there is a universal 
    /// method for all hooks, regardless of type!
    /// </summary>
    /// <param name="hook">The custom hook to be processed.</param>
    protected virtual void customHook(Hook hook)
    {
        switch (hook.type)
        {
            default:
                Debug.Log("Hook switch defaulted: Unknown hook type received. Did you add a new type and forget to update this?");
                break;
        }
    }

    // Override the ones of these stubs that you actually use.

    protected virtual void actionHook(ActionHook hook)
    {
        return;
    }

    protected virtual void analyticsHook(AnalyticsHook hook)
    {
        return;
    }

    protected virtual void errorHook(ErrorHook hook)
    {
        return;
    }

    protected virtual void failHook(FailHook hook)
    {
        return;
    }

    protected virtual void gameObjectHook(GameObjectHook hook)
    {
        return;
    }

    protected virtual void idleHook(IdleHook hook)
    {
        return;
    }

    protected virtual void inputHook(InputHook hook)
    {
        return;
    }

    protected virtual void successHook(SuccessHook hook)
    {
        return;
    }

    protected virtual void taskHook(TaskHook hook)
    {
        return;
    }
}