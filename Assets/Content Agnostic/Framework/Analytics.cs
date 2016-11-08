using UnityEngine;
using System.Collections;

public class Analytics {

    /// <summary>
    /// analyticsType should be an enum but for now lets work with a string
    /// </summary>
    public string analyticsType { get; set; }
    public string analyticsMessage { get; set; }

    public Analytics(string analyticsType, string analyticsMessage)
    {        
        this.analyticsType = analyticsType;
        this.analyticsMessage = analyticsMessage;
    }
}