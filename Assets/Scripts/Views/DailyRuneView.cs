using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DailyRuneView : Element
{
    //public bool onMenu = true;
    public RectTransform divinationExplain;
    public RectTransform preLoader;
    public int countDown = 6;

    public GameObject staticRune;
    public GameObject quickRune;
    //public GameObject forDestroy;

    public Text divinationText;
    public Text runeName;
    public Text count;

    private int rnd;
    private GameObject runeSign;

    //private void Update()
    //{
    //    if(onMenu)
    //        transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    //}

    public void CheckDailyRune()
    {
        Instantiate(quickRune, staticRune.transform.position, staticRune.transform.rotation, gameObject.transform);

        rnd = Random.Range(0, 24);
        Sequence showRune = DOTween.Sequence();

        //onMenu = false;
        runeSign = app.model.runesList[rnd].RunePrefab;

        showRune.AppendInterval(1);
        showRune.InsertCallback(0, () => { app.cameraController.QuickCameraView(); });

        showRune.Append(transform.DOMove(new Vector3(0.1f, 13, 2), 2));
        //showRune.InsertCallback(1, () => { app.cameraController.DailyCameraView(); });

        showRune.Join(transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => { preLoader.gameObject.SetActive(true); StartCoroutine(Timer()); });

        showRune.AppendInterval(5);
        showRune.AppendCallback(() => { preLoader.gameObject.SetActive(false);  });
        //showRune.AppendCallback(() => { app.cameraController.divinationShowCameraView(); DivinationShow(); });
    }

    private void DivinationShow()
    {
        Instantiate(runeSign, transform.position, runeSign.transform.rotation, gameObject.transform);
        divinationExplain.gameObject.SetActive(true);

        runeName.text = app.model.runesList[rnd].RuneName;
        divinationText.text = app.model.runesList[rnd].RuneDescription;
    }

    private IEnumerator Timer()
    {
        for (;;)
        {
            countDown--;
            count.text = countDown.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    public void GoToMenu()
    {
        //onMenu = true;
        app.cameraController.MenuCameraView();
        for (int i = transform.childCount; i > 0; --i)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }
}
