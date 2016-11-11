using UnityEngine;
using System.Collections;

/// <summary>
/// Do NOT modify this class! A Task
/// represents a generic goal for the
/// player to accomplish in the game.
/// You can either have your mechanics
/// build this class directly, or make
/// a new class that inherits it if you
/// need specific behavior.
/// </summary>
public class Task
{
    public int numTries { get; set; }
    public bool passed { get; set; }
    private int activeSub { get; set; }
    private ArrayList subTasks { get; set; }

    public Task()
    {
        numTries = 0;
        passed = false;
        activeSub = 0;
        subTasks = new ArrayList();
    }

    public Task(ArrayList list)
    {
        numTries = 0;
        passed = false;
        activeSub = 0;
        subTasks = (ArrayList)list.Clone();
    }

    // Marking all methods as virtual in case you make a child class.
    public virtual bool hasSubTasks()
    {
        return subTasks.Count > 0;
    }

    public virtual Task getActiveSub()
    {
        Task temp;
        if(hasSubTasks())
        {
            temp = (Task)subTasks[activeSub];
        }
        else
        {
            temp = this;
        }
        return temp;
    }

    public virtual void markPassed()
    {
        passed = true;
    }
}
