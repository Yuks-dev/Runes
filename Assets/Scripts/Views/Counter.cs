using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : Element
{
    public int countDown = 5;
    public Text count;

    private void OnEnable()
    {
        StartCoroutine(Timer(countDown));
        app.aux.CountSound();
    }

    private IEnumerator Timer(int index)
    {
        for (int i = index; i >= 0; i--)
        {
            count.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
