using UnityEngine;
using UnityEngine.UI;

public class DescriptionView : Element
{
    public GameObject activePanel;
    public GameObject inactivePanel;
    public GameObject close;

    [Space]
    public Text nameRune;
    public Text descriptionRune;
    public Text shortDescription;
    public Image signView;
    public Image runeImg;
    public Sprite goldenRune;
    public Sprite normalRune;

    public Image progress;
    public Text progressText;

    public void DescShow(int index)
    {
        close.gameObject.SetActive(false);
        gameObject.SetActive(true);

        if (app.model.availableRunes[index] > 0)
        {
            activePanel.SetActive(true);
            inactivePanel.SetActive(false);
            SetUI(index);
            Counter(index);

            if (app.model.availableRunes[index] >= 50)
                runeImg.sprite = goldenRune;
            else
                runeImg.sprite = normalRune;
        }
        else
        {
            app.ad.chooseRune = index;
            inactivePanel.SetActive(true);
            activePanel.SetActive(false);
        }
    }

    private void OnDisable()
    {
        close.gameObject.SetActive(true);
    }
        

    private void SetUI(int index)
    {
        nameRune.text = app.model.runesCollection[index].RuneName;

        descriptionRune.text = app.model.runesCollection[index].RuneDescription;
        if(app.model.language == MainModel.Localization.Russian)
            descriptionRune.text = app.model.runesCollection[index].RuneDescriptionRu;
        if (app.model.language == MainModel.Localization.Spanish)
            descriptionRune.text = app.model.runesCollection[index].RuneDescriptionEsp;
        if (app.model.language == MainModel.Localization.Korean)
            descriptionRune.text = app.model.runesCollection[index].RuneDescriptionKor;

        shortDescription.text = app.model.runesCollection[index].RuneShortExplain;
        if(app.model.language == MainModel.Localization.Russian)
            shortDescription.text = app.model.runesCollection[index].RuneShortExplainRu;
        if (app.model.language == MainModel.Localization.Spanish)
            shortDescription.text = app.model.runesCollection[index].RuneShortExplainEsp;
        if (app.model.language == MainModel.Localization.Korean)
            shortDescription.text = app.model.runesCollection[index].RuneShortExplainKor;

        signView.sprite = app.model.runesCollection[index].RuneImage;
    }

    private void Counter(int index)
    {
        float count = app.model.availableRunes[index];
        progressText.text = count.ToString();
        progress.fillAmount = count / 50;
    }
}
