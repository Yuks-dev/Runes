using DG.Tweening;
using UnityEngine;

public class QuickDivController : Element
{
    public GameObject quickRune;
    public GameObject view;

    public MenuController menu;
    public QuickDivUIView ui;

    private int rnd;
    private GameObject runeSign;
    private bool onRotate = true;

    private void Update()
    {
        if(onRotate)
            quickRune.transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }

    public void LaunchDivination()
    {
        rnd = Random.Range(0, 24);
        runeSign = app.model.runesList[Random.Range(0, 24)].RunePrefab;

        app.cameraController.QuickCameraView();
        menu.tapPlaces.gameObject.SetActive(false);

        ui.StartTimer();
        RuneAnimation();
    }

    private void RuneAnimation()
    {
        Sequence showRune = DOTween.Sequence();
        showRune.PrependInterval(ui.countDown);
        showRune.AppendCallback(() => { onRotate = false; });
        showRune.Append(quickRune.transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => { ShowDescription(); });
    }

    private void ShowDescription()
    {
        ui.OnDescribe(rnd);
        Instantiate(runeSign, quickRune.transform.position, transform.rotation, view.gameObject.transform);
    }

    public void BackToMenu()
    {
        app.ad.ShowAd();
        menu.SetStart();
        onRotate = true;

        for (int i = view.transform.childCount; i > 0; --i)
            DestroyImmediate(view.transform.GetChild(0).gameObject);
    }
}
