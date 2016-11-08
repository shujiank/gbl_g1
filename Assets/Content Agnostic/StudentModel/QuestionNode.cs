using UnityEngine;
using System.Collections;

/// <summary>
/// This represents a single question node
/// in the knowledge tracing graph for the
/// student model.
/// </summary>
public class QuestionNode
{
    public string name { get; private set; }

    public QuestionNode()
    {
        name = "NONE";
    }

    public QuestionNode(string n)
    {
        name = n;
    }
}
