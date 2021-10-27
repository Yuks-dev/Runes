using UnityEngine;

public class Element : MonoBehaviour
{
    public App app => App.Instance;
}

public class App : MonoBehaviour
{
    private static App s_Instance;
    public static App Instance => s_Instance;

    public MainModel model; // Models (data, scriptable states)
    //public MainView view;   // Viewers (only get data from models, send events to controllsers)
    public RuneController controller;   // Controllers (get events from views, update models)
    public CameraController cam;
    public AdsManager ad;
    public AudioController aux;

    private void Awake() => s_Instance = this;
}


