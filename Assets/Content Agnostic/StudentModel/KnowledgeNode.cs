using UnityEngine;
using System.Collections;

/// <summary>
/// This class represents a single knowledge node
/// that links with a given question node in the 
/// student model knowledge tracing graph.
/// </summary>
public class KnowledgeNode
{
    public string name { get; private set; }
    public QuestionNode matchingNode { get; private set; }
    public bool learned { get; private set; }

    public KnowledgeNode()
    {
        name = "NONE";
        matchingNode = new QuestionNode();
        learned = false;
    }

    public KnowledgeNode(string n, QuestionNode mn)
    {
        name = n;
        matchingNode = mn;
        learned = true;
    }
}
