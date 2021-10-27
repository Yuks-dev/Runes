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

    private int rnd;
    private GameObject runeSign;
    private bool onRotate = true;
    //public bool adsOn = true;

    private void Update()
    {
        if(onRotate)
            quickRune.transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }

    public void LaunchDivination()
    {
        rnd = Random.Range(0, 24);
        runeSign = app.model.runesList[Random.Range(0, 24)].RunePrefab;
        menu.tapPlaces.gameObject.SetActive(false);

        app.cam.OnQuickMove(counter.gameObject);
        RuneAnimation();
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
        Instantiate(runeSign, quickRune.transform.position, transform.rotation, view.gameObject.transform);
    }

    public void BackToMenu()
    {
        //if(adsOn)
        app.ad.ShowInterstitialAD();
        menu.SetStart();
        //adsOn = false;
        onRotate = true;
        for (int i = view.transform.childCount; i > 0; --i)
            DestroyImmediate(view.transform.GetChild(0).gameObject);
    }
}
