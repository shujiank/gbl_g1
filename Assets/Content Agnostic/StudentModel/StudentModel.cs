using UnityEngine;
using System.Collections;

public static class StudentModel
{
    // Knowledge parameters
    private static float priorKnowledgeParam { get; set; }
    private static float rateOfLearning { get; set; }

    // Performance parameters
    private static float guessRate { get; set; }
    private static float slipRate { get; set; }

    // The task the student is currently attempting.
    public static Task currentTask { private get; set; }

    // The point that accepts all Hooks.
    public static void acceptHook(Hook hook)
    {
        FileManagement.printToFile("Hook Received -> " + hook);
    }
}
