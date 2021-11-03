using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreloadView : MonoBehaviour
{
    public int setLanguage = -1;
    public Image loadProgress;
    public GameObject loadingPanel;
    public GameObject languagePanel;

    private void Start()
    {
        LoadLanguage();

        //if (setLanguage >= 0)
        //    Loading();
    }

    public void Loading()
    {
        languagePanel.SetActive(false);
        loadingPanel.SetActive(true);
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

    public void SaveLanguage(int index)
    {
        setLanguage = index;
        PlayerPrefs.SetInt("SaveLanguage", setLanguage);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("SaveLanguage"))
            setLanguage = PlayerPrefs.GetInt("SaveLanguage");
        else
            Debug.Log("There is no save data!");
    }
}
