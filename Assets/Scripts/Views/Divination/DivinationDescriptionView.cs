using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DivinationDescriptionView : Element
{
    public RectTransform descPanel;
    public RectTransform descBubble;

    public Text runeName;
    public Text runeNumber;
    public Text runeDescribe;

    private bool isShown = false;
    private bool descActive = false;

    public void DescriptionButton()
    {
        if (!isShown && descActive)
            ShowDescription();
        else
            HideDescription();
    }

    public void ShowDescription()
    {
        DescriptionText();
        app.aux.OpenSound();
        descActive = true;

        descBubble.DOAnchorPos(Vector2.zero, 0.5f);
        runeDescribe.transform.DOScale(1, 0.5f).SetEase(Ease.OutFlash);
        descPanel.DOAnchorPos(Vector2.zero, 0.5f);
        isShown = true;
    }

    public void HideDescription()
    {
        descBubble.DOAnchorPos(new Vector2(205, -150), 0.5f);
        runeDescribe.transform.DOScale(0, 0.5f);
        descPanel.DOAnchorPos(new Vector2(130, -350), 0.5f);
        isShown = false;
    }

    private void DescriptionText()
    {
        int index = app.controller.runeCount;

        runeNumber.text = index.ToString();
        runeNumber.gameObject.transform.DOShakeRotation(1);

        runeName.text = app.controller.runesOnScene[index - 1].RuneName;
        runeDescribe.text = app.controller.runesOnScene[index - 1].RuneDescription;
        DescriptionLocalization(index);
    }

    private void DescriptionLocalization(int index)
    {
        if (app.model.language == MainModel.Localization.Russian)
            runeDescribe.text = app.controller.runesOnScene[index - 1].RuneDescriptionRu;
        if (app.model.language == MainModel.Localization.Spanish)
            runeDescribe.text = app.controller.runesOnScene[index - 1].RuneDescriptionEsp;
        if (app.model.language == MainModel.Localization.Korean)
            runeDescribe.text = app.controller.runesOnScene[index - 1].RuneDescriptionKor;
    }
}
