using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuickDivController : Element
{
    public GameObject quickRune;
    public GameObject view;
    public MenuController menu;
    public Counter counter;
    [Space]
    public RectTransform divinationPanel;
    public Text divinationText;
    public Text runeName;

    public int rnd;
    public GameObject runeSign;
    private bool onRotate = true;

    private void Update()
    {
        if(onRotate)
            quickRune.transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }

    public void LaunchDivination()
    {
        rnd = Random.Range(0, 24);
        runeSign = app.model.runesList[rnd].RunePrefab;
        menu.tapPlaces.gameObject.SetActive(false);
        app.cam.OnQuickMove(counter.gameObject);
        RuneAnimation();
    }

    public void BackToMenu()
    {
        app.ad.ShowInterstitialAD();
        menu.SetStart();
        onRotate = true;
        for (int i = view.transform.childCount; i > 0; --i)
            DestroyImmediate(view.transform.GetChild(0).gameObject);
    }

    private void RuneAnimation()
    {
        Sequence showRune = DOTween.Sequence();
        showRune.PrependInterval(counter.countDown);
        showRune.AppendCallback(() => { onRotate = false; });
        showRune.Append(quickRune.transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => { ShowDescription(); app.aux.RotateSound(); });
    }

    private void ShowDescription()
    {
        counter.gameObject.SetActive(false);
        divinationPanel.gameObject.SetActive(true);
        app.aux.OpenSound();
        runeName.text = app.model.runesList[rnd].RuneName;
        divinationText.text = app.model.runesList[rnd].RuneDescription;
        DescriptionLocalization();
        Instantiate(runeSign, quickRune.transform.position, transform.rotation, view.gameObject.transform);
    }

    private void DescriptionLocalization()
    {
        if (app.model.language == MainModel.Localization.Russian)
            divinationText.text = app.model.runesList[rnd].RuneDescriptionRu;
        if (app.model.language == MainModel.Localization.Spanish)
            divinationText.text = app.model.runesList[rnd].RuneDescriptionEsp;
        if (app.model.language == MainModel.Localization.Korean)
            divinationText.text = app.model.runesList[rnd].RuneDescriptionKor;
    }
}
