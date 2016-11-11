using UnityEngine;
using System.Collections;

/// <summary>
/// The hook used when you need to collect
/// analytics(forcefully) on an event or action
/// </summary>
public class AnalyticsHook : Hook
{
    Analytics analyticsData;

    public AnalyticsHook(Analytics data)
    {
        type = HookType.Analytics;
        analyticsData = data;
    }

    public override string ToString()
    {
        return "Analytics generated. Type:" + analyticsData.analyticsType + "::" + analyticsData.analyticsMessage;
    }
}