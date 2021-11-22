using System.Collections.Generic;

interface IAnalytics
{
    void SendEvent(string eventName);
    void SendEvent(string eventName, Dictionary<string, object> eventData);
}
