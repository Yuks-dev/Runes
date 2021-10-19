using System;
using System.Collections.Generic;
using UnityEngine;

public class MainModel : Element
{
    public enum ChooseState { Runes4, Runes7, Runes13, MainMenu }
    public ChooseState currentState;

    public SaveSystem saveSystem;
    public GameObject runePrefab;
    public GameObject runesGame;
    public GameObject mainMenu;
    public List<StateData> stateList = new List<StateData>(4);
    public List<RunesData> runesList = new List<RunesData>(24);

    public int[] availableRunes = new int[24];

    private void Awake()
    {
        app.model = this;
        LoadData();
    }

    public void LoadData() => saveSystem.LoadAppData();
    public void SaveData() => saveSystem.SaveAppData();
}