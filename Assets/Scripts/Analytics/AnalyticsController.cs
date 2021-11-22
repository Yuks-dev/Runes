using UnityEngine;

public class AnalyticsController : MonoBehaviour
{
    private IAnalytics[] services;
    private void Awake() => services = new IAnalytics[] { new AnalyticsService() };

    private void SendEvent(string eventName)
    {
        for (int i = 0; i < services.Length; i++)
            services[i].SendEvent(eventName);
    }


    // Events List:
    public void SendMainMenuOpened() => SendEvent("Main Menu Opened");
    public void SendChooseYellow() => SendEvent("Choose Yellow");
    public void SendChooseBlue() => SendEvent("Choose Blue");
    public void SendBuyPoints(float pointsValue) => SendEvent("Buy Points: " + pointsValue);



}
