using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : Element
{
    private AndroidNotification notification1;
    private AndroidNotification notification2;
    private AndroidNotification notification3;
    private AndroidNotification notification4;
    private AndroidNotification notification5;

    private string englTitle = "Welcome to Daily Rune Subscription!";
    private string englText = "Your first rune prediction will be tomorrow morning";

    private string rusTitle = "Добро пожаловать!";
    private string rusText = "Ждите ваше руническое предсказание завтра утром";

    private string espTitle = "¡Bienvenido a la suscripción diaria a runas";
    private string espText = "Tu primera predicción de runas será mañana por la mañana";

    private string korTitle = "일일 룬 구독에 오신 것을 환영합니다!";
    private string korText = "첫 번째 룬 예측은 내일 아침입니다";


    private void Start()
    {
        if (!PlayerPrefs.HasKey("PushAvailable"))
        {
            PlayerPrefs.SetInt("PushAvailable", 1);
            PlayerPrefs.Save();
            CreateNotification();

            if(app.model.language == MainModel.Localization.English)
                WelcomeNotification(englTitle, englText);

            if (app.model.language == MainModel.Localization.Russian)
                WelcomeNotification(rusTitle, rusText);

            if (app.model.language == MainModel.Localization.Spanish)
                WelcomeNotification(espTitle, espText);

            if (app.model.language == MainModel.Localization.Korean)
                WelcomeNotification(korTitle, korText);

            SendNotification(notification1, 1);
            SendNotification(notification2, 2);
            SendNotification(notification3, 3);
            SendNotification(notification4, 4);
            SendNotification(notification5, 5);
        } 
    }

    private void CreateNotification()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "DailyRune",
            Name = "Daily Rune",
            Description = "Sending your daily rune prediction",
            Importance = Importance.High,

            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    private void WelcomeNotification(string title, string text)
    {
        AndroidNotification welcome = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = DateTime.Now.AddSeconds(5),
            SmallIcon = "icon_s",
            LargeIcon = "icon_l",
        };
        AndroidNotificationCenter.SendNotification(welcome, "DailyRune");
    }

    private void SendNotification(AndroidNotification push, int days)
    {
        int rnd = UnityEngine.Random.Range(1, 24);

        string titleEng = "Your Daily Rune: " + app.model.runesCollection[rnd].RuneName;
        string textEng = app.model.runesCollection[rnd].RuneShortExplain;

        string titleRu = "Ваша руна дня: " + app.model.runesCollection[rnd].RuneName;
        string textRu = app.model.runesCollection[rnd].RuneShortExplainRu;

        string titleEsp = "Tu carrera diaria: " + app.model.runesCollection[rnd].RuneName;
        string textEsp = app.model.runesCollection[rnd].RuneShortExplainEsp;

        string titleKor = "당신의 일일 달리기: " + app.model.runesCollection[rnd].RuneName;
        string textKor = app.model.runesCollection[rnd].RuneShortExplainKor;

        if (app.model.language == MainModel.Localization.English)
        {
            push = new AndroidNotification()
            {
                Title = titleEng, Text = textEng,
                SmallIcon = "icon_s", LargeIcon = "icon_l",
                FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(days),
            };
            AndroidNotificationCenter.SendNotification(push, "DailyRune");
        }

        if (app.model.language == MainModel.Localization.Russian)
        {
            push = new AndroidNotification()
            {
                Title = titleRu, Text = textRu,
                SmallIcon = "icon_s", LargeIcon = "icon_l",
                FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(days),
            };
            AndroidNotificationCenter.SendNotification(push, "DailyRune");
        }

        if (app.model.language == MainModel.Localization.Spanish)
        {
            push = new AndroidNotification()
            {
                Title = titleEsp, Text = textEsp,
                SmallIcon = "icon_s", LargeIcon = "icon_l",
                FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(days),
            };
            AndroidNotificationCenter.SendNotification(push, "DailyRune");
        }

        if (app.model.language == MainModel.Localization.Korean)
        {
            push = new AndroidNotification()
            {
                Title = titleKor, Text = textKor,
                SmallIcon = "icon_s", LargeIcon = "icon_l",
                FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0).AddDays(days),
            };
            AndroidNotificationCenter.SendNotification(push, "DailyRune");
        }
    }
}
