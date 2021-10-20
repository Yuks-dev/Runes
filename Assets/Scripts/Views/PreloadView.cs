using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreloadView : MonoBehaviour
{
    public Image loadProgress;

    private void Start()
    {
        Invoke(nameof(Loading),1);
    }

    private void Loading()
    {
        StartCoroutine(AsyncLoad());
    }

    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while(operation.progress < 1)
        {
            loadProgress.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
