using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InterfaceController : Element
{
    public DivinationDescriptionView descriptionView;
    public GameObject runeAddPanel;
    public GameObject statePanel;
    public GameObject resultPanel;
    public Text stateText;
    private int stateCount = 0;

    private void Awake() => app.controller.ui = this;

    public void GoToMenu() // End
    {
        Instantiate(app.model.mainMenu);
        Destroy(app.controller.gameObject);
    }

    private void ActivatePanels(bool state)
    {
        statePanel.SetActive(state);
        descriptionView.gameObject.SetActive(state);
    }

    public void SetDescription()
    {
        runeAddPanel.gameObject.SetActive(true);
        descriptionView.ShowDescription();
        descriptionView.runeName.gameObject.SetActive(true);
    }

    public void StopDescription()
    {
        descriptionView.HideDescription();
        descriptionView.runeName.gameObject.SetActive(false);
    }

    public void SetState() // Show state and result
    {
        ActivatePanels(true);
        stateText.text = app.controller.state.StateDescription[app.controller.runeCount];
        stateText.gameObject.transform.DOShakeScale(1);

        StateLocalization();
        stateCount++;

        if (app.controller.state.StateDescription.Length == stateCount)
        {
            resultPanel.SetActive(true);
            ActivatePanels(false);
        }
    }

    private void StateLocalization()
    {
        if (app.model.language == MainModel.Localization.Russian)
            stateText.text = app.controller.state.StateDescriptionRu[app.controller.runeCount];
        if (app.model.language == MainModel.Localization.Spanish)
            stateText.text = app.controller.state.StateDescriptionEsp[app.controller.runeCount];
        if (app.model.language == MainModel.Localization.Korean)
            stateText.text = app.controller.state.StateDescriptionKor[app.controller.runeCount];
    }
}
