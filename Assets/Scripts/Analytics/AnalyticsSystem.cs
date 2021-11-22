using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class AnalyticsSystem : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    private void CustomEvents()
    {
        // Send custom event
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "fabulousString", "hello there" },
            { "sparklingInt", 1337 },
            { "spectacularFloat", 0.451f },
            { "peculiarBool", true },
        };
        // The ‘myEvent’ event will get queued up and sent every minute
        //Events.CustomData("myEvent", parameters);

    }
}
