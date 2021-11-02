using UnityEngine;
using UnityEngine.UI;

public class DescriptionView : Element
{
    public GameObject activePanel;
    public GameObject inactivePanel;

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
            inactivePanel.SetActive(true);
            activePanel.SetActive(false);
        }
            
    }

    private void SetUI(int index)
    {
        nameRune.text = app.model.runesCollection[index].RuneName;
        descriptionRune.text = app.model.runesCollection[index].RuneDescription;
        shortDescription.text = app.model.runesCollection[index].RuneShortExplain;
        signView.sprite = app.model.runesCollection[index].RuneImage;
    }

    private void Counter(int index)
    {
        float count = app.model.availableRunes[index];
        progressText.text = count.ToString();
        progress.fillAmount = count / 50;
    }
}
