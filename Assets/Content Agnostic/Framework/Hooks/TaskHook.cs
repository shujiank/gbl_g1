using UnityEngine;
using System.Collections;

/// <summary>
/// This is the hook for sending a
/// Task object to the content.
/// </summary>
public class TaskHook : Hook
{
    public Task myTask { get; private set; }

    public TaskHook(Task t)
    {
        type = HookType.Task;
        myTask = t;
    }

    public override string ToString()
    {
        return "Task: " + myTask.ToString();
    }
}
