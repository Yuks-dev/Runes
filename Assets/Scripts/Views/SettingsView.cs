using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsView : Element
{
    public GameObject settingsPanel;
    public int setLanguage;

    public void SaveLanguage(int index)
    {
        setLanguage = index;
        PlayerPrefs.SetInt("SaveLanguage", setLanguage);
        PlayerPrefs.Save();

        settingsPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Clear()
    {
        if (app.controller)
            Destroy(app.controller.gameObject);
        if (app.menu)
            Destroy(app.menu.gameObject);
    }
}
