using System.Collections.Generic;
using UnityEngine;

public class RuneController : Element
{
    public bool canTake;
    public bool runeLaunch;

    public int runeCount;

    private List<RunesData> runesTempList = new List<RunesData>(24);
    public List <RunesData> runesOnScene = new List<RunesData>(14);
    [Space]
    public InterfaceController ui;
    public StateData state;

    private void Awake() => app.controller = this;

    private void Start()
    {
        state = app.model.stateList[((int)app.model.currentState)];
        ShuffleRunes(app.model.runesList, runesTempList);
        SetRunesOnScene(runesOnScene, state, app.model.runesList);
    }

    public void MakeAvailable()
    {
        runeCount++;
        app.model.availableRunes[runesOnScene[runeCount - 1].RuneIndex] += 1;
        app.model.SaveData();
    }

    private void SetRunesOnScene(List<RunesData> r_scene, StateData r_state, List<RunesData> mainList) // Component
    {
        r_scene.Clear();

        for (int i = 0; i < r_state.RunesCount; i++)
        {
            int rnd = Random.Range(0, r_state.RunesCount);
            if (!r_scene.Contains(mainList[rnd]))
                r_scene.Add(mainList[rnd]);
            else i--;
        }
    }

    private void ShuffleRunes(List<RunesData> mainList, List<RunesData> tempList) // Component
    {
        int index = mainList.Count;
        for (int i = 0; i < index; i++)
        {
            int rnd = Random.Range(0, mainList.Count);
            tempList.Add(mainList[rnd]);
            mainList.RemoveAt(rnd);
        }
        app.model.runesList = runesTempList;
    }
}
