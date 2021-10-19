using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DailyRuneView : Element
{
    public bool onMenu = true;
    private GameObject runeSign;

    private void Update()
    {
        if(onMenu)
            transform.Rotate(Vector3.right, 100 * Time.deltaTime);
    }

    public void CheckDailyRune()
    {
        var rnd = Random.Range(0, 24);

        onMenu = false;
        runeSign = app.model.runesList[rnd].RunePrefab;

        Sequence showRune = DOTween.Sequence();

        showRune.Append(transform.DOMove(new Vector3(0, 13, 2), 2));
        showRune.InsertCallback(0,() => { app.cameraController.DailyCameraView(); });
        showRune.Join(transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => { Instantiate(runeSign, transform.position, runeSign.transform.rotation, gameObject.transform); });
    }
        
}
