using UnityEngine;
using UnityEngine.UI;

public class ResultController : Element
{
    public GameObject runes4;
    public GameObject runes7;
    public GameObject runes13;
    [Space]
    public Image runeImage;
    public Text runeName;
    public Text stateText;
    public Text runeDescribe;

    private void Start()
    {
        if (app.model.currentState == MainModel.ChooseState.Runes4)
            runes4.SetActive(true);

        if (app.model.currentState == MainModel.ChooseState.Runes7)
            runes7.SetActive(true);

        if (app.model.currentState == MainModel.ChooseState.Runes13)
            runes13.SetActive(true);

        ShowRuneResult(0);
    }

    public void ShowRuneResult(int index)
    {
        runeImage.sprite = app.controller.runesOnScene[index].RuneImage;
        runeName.text = app.controller.runesOnScene[index].RuneName;
        runeDescribe.text = app.controller.runesOnScene[index].RuneDescription;
        stateText.text = app.controller.state.StateDescription[index];
    }
}
