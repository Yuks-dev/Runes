using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuickDivUIView : Element
{
    public int countDown = 5;

    public Text divinationText;
    public Text runeName;
    public Text count;
    public RectTransform divinationExplain;
    public RectTransform preLoader;

    public void OnDescribe(int rnd)
    {
        preLoader.gameObject.SetActive(false);
        divinationExplain.gameObject.SetActive(true);
        runeName.text = app.model.runesList[rnd].RuneName;
        divinationText.text = app.model.runesList[rnd].RuneDescription;
    }

    public void StartTimer()
    {
        preLoader.gameObject.SetActive(true);
        StartCoroutine(Timer());
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

}
