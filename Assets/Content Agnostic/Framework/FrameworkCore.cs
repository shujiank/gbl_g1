using UnityEngine;
using System.Collections;

/// <summary>
/// Do NOT modify this class!
/// This class holds game wide info,
/// such as the current content domain.
/// </summary>
public static class FrameworkCore
{
    public static Content currentContent { get; private set; }

    public static void setContent(Content con)
    {
        currentContent = con;
    }
}
