using UnityEngine;
using UnityEngine.UI;

public class ResultController : Element
{
    public GameObject runes4;
    public GameObject runes7;
    public GameObject runes13;
    public Sprite activePoint;
    public Sprite inactivePoint;
    [Space]
    public Image runeImage;
    public Text runeName;
    public Text stateText;
    public Text runeDescribe;

    private void OnEnable() => app.model.winEffect.SetActive(true);

    private void Start()
    {
        app.ad.RequestInterstitial();

        if (app.model.currentState == MainModel.ChooseState.Runes4)
            runes4.SetActive(true);

        if (app.model.currentState == MainModel.ChooseState.Runes7)
            runes7.SetActive(true);

        if (app.model.currentState == MainModel.ChooseState.Runes13)
            runes13.SetActive(true);

        ShowRuneResult(0);
    }

    private void OnDisable()
    {
        app.model.winEffect.SetActive(false);
        app.ad.ShowInterstitialAD();
    }
        

    public void ShowRuneResult(int index)
    {
        runeImage.sprite = app.controller.runesOnScene[index].RuneImage;
        runeName.text = app.controller.runesOnScene[index].RuneName;

        runeDescribe.text = app.controller.runesOnScene[index].RuneDescription;
        if(app.model.language == MainModel.Localization.Russian)
            runeDescribe.text = app.controller.runesOnScene[index].RuneDescriptionRu;
        if (app.model.language == MainModel.Localization.Spanish)
            runeDescribe.text = app.controller.runesOnScene[index].RuneDescriptionEsp;
        if (app.model.language == MainModel.Localization.Korean)
            runeDescribe.text = app.controller.runesOnScene[index].RuneDescriptionKor;

        stateText.text = app.controller.state.StateDescription[index];
        if(app.model.language == MainModel.Localization.Russian)
            stateText.text = app.controller.state.StateDescriptionRu[index];
        if (app.model.language == MainModel.Localization.Spanish)
            stateText.text = app.controller.state.StateDescriptionEsp[index];
        if (app.model.language == MainModel.Localization.Korean)
            stateText.text = app.controller.state.StateDescriptionKor[index];
    }
}
