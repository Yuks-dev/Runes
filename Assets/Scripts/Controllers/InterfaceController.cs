using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InterfaceController : Element
{
    public GameObject descPanel;
    public RectTransform descBubble;
    public RectTransform description;
    [Space]
    public GameObject statePanel;
    public GameObject resultPanel;
    [Space]
    public Text stateText;
    public Text runeNumber;
    public Text runeName;
    public Text runeDescribe;

    private bool isShown = false;
    private int stateCount = 0;

    private void Awake() => app.controller.ui = this;

    public void DescriptionButton()
    {
        if (!isShown)
            ShowDescription();
        else
            HideDescription();
    }

    public void ShowDescription()
    {
        descBubble.DOAnchorPos(new Vector3(0,0,0),1);
        description.DOAnchorPosY(-120, 1);
        descPanel.transform.DOLocalMoveY(410, 1).SetEase(Ease.OutQuart);
        isShown = true;
    }

    public void HideDescription()
    {
        descBubble.DOAnchorPos(new Vector3(190, -140, 0), 1);
        description.DOAnchorPosY(-250, 1);
        descPanel.transform.DOLocalMoveY(-90, 1).SetEase(Ease.OutQuart);
        isShown = false;
    }

    public void PrepareNextRune()
    {
        runeName.gameObject.SetActive(false);
        HideDescription();
    }

    public void SetState() // Show state and result
    {
        ActivatePanels(true);
        stateText.text = app.controller.state.StateDescription[app.controller.runeCount];
        stateCount++;

        if (app.controller.state.StateDescription.Length == stateCount)
        {
            resultPanel.SetActive(true);
            ActivatePanels(false);
        }
    }

    public void GoToMenu() // End
    {
        Instantiate(app.model.mainMenu);
        Destroy(app.controller.gameObject);
    }

    public void DescriptionText(int index)
    {
        runeNumber.text = index.ToString();
        runeName.text = app.controller.runesOnScene[index - 1].RuneName;
        runeDescribe.text = app.controller.runesOnScene[index - 1].RuneDescription;
    }

    private void ActivatePanels(bool state)
    {
        statePanel.SetActive(state);
        descPanel.SetActive(state);
    }
}
