using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainModel : Element
{
    public int onRate;
    public GameObject winEffect;

    public TMP_FontAsset koreanFont;
    public TMP_FontAsset latinFont;
    public TMP_FontAsset cyrilicFont;

    public enum Localization { English, Russian, Spanish, Korean }
    public Localization language;

    public enum ChooseState { Runes4, Runes7, Runes13, MainMenu }
    public ChooseState currentState;

    public SaveSystem saveSystem;
    public GameObject runePrefab;
    public GameObject runesGame;
    public GameObject mainMenu;

    public List<StateData> stateList = new List<StateData>(4);
    public List<RunesData> runesList = new List<RunesData>(24);
    public List<RunesData> runesCollection = new List<RunesData>(24);

    public int[] availableRunes = new int[24];

    private void Awake()
    {
        app.model = this;
        LoadData();
        LoadLanguage();
    }

    public void LoadData() => saveSystem.LoadAppData();
    public void SaveData() => saveSystem.SaveAppData();

    private void Start()
    {
        Instantiate(mainMenu, new Vector3(0,2,0), Quaternion.identity);
    }

    private void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("SaveLanguage"))
        {
            if (PlayerPrefs.GetInt("SaveLanguage") <= 0)
                language = Localization.English;
            if (PlayerPrefs.GetInt("SaveLanguage") == 1)
                language = Localization.Russian;
            if (PlayerPrefs.GetInt("SaveLanguage") == 2)
                language = Localization.Spanish;
            if (PlayerPrefs.GetInt("SaveLanguage") == 3)
                language = Localization.Korean;
        }
        else
            language = Localization.English;
    }
}