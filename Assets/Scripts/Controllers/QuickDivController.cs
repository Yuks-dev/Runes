using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuickDivController : Element
{
    public GameObject quickRune;
    public GameObject view;
    private int countDown = 5;

    public Text divinationText;
    public Text runeName;
    public Text count;

    public RectTransform divinationExplain;
    public RectTransform preLoader;

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
        preLoader.gameObject.SetActive(true);

        StartCoroutine(Timer());
        RuneAnimation();
    }

    private void RuneAnimation()
    {
        Sequence showRune = DOTween.Sequence();
        showRune.PrependInterval(countDown);
        showRune.AppendCallback(() => { onRotate = false; });
        showRune.Append(quickRune.transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => { ShowDescription(); });
    }

    private void ShowDescription()
    {
        preLoader.gameObject.SetActive(false);
        divinationExplain.gameObject.SetActive(true);

        Instantiate(runeSign, quickRune.transform.position, runeSign.transform.rotation, view.gameObject.transform);
        runeName.text = app.model.runesList[rnd].RuneName;
        divinationText.text = app.model.runesList[rnd].RuneDescription;
    }

    private IEnumerator Timer()
    {
        int index = countDown;
        for (int i = index; i >= 0; i--)
        {
            count.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void BackToMenu()
    {
        app.cameraController.MenuCameraView();
        onRotate = true;
        for (int i = view.transform.childCount; i > 0; --i)
            DestroyImmediate(view.transform.GetChild(0).gameObject);
    }
}
