using UnityEngine;
using UnityEngine.UI;

public class RuneCollectionView : Element
{
    public int runeIndex;
    public Image runeSign;
    public Image runeImage;
    public Sprite goldenRune;
    public Image playReward;
    public Image progressBar;
    public Text progressText;

    private void Start() => SetCollection();
    private void Update() =>  SetCollection();

    private void SetCollection()
    {
        float count = app.model.availableRunes[runeIndex];
        progressText.text = count.ToString();
        progressBar.fillAmount = count / 50;

        if (count == 0)
        {
            runeSign.gameObject.SetActive(false);
            playReward.gameObject.SetActive(true);
            runeImage.color = new Color(1, 1, 1, 0.4f);
        }

        if (count >= 50)
        {
            runeImage.sprite = goldenRune;
            playReward.gameObject.SetActive(false);
            runeImage.color = new Color(1, 1, 1, 1);
        }

        if (count > 0 && count < 50)
        {
            runeSign.gameObject.SetActive(true);
            playReward.gameObject.SetActive(false);
            runeImage.color = new Color(1, 1, 1, 1);
        }    
    }
}
