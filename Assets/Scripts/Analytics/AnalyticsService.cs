using System.Collections.Generic;
using UnityEngine.Analytics;

public class AnalyticsService : IAnalytics
{
    public void SendEvent(string eventName) => Analytics.CustomEvent(eventName);
    public void SendEvent(string eventName, Dictionary<string, object> eventData) => Analytics.CustomEvent(eventName, eventData);
}
