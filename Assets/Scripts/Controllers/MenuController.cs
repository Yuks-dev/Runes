using UnityEngine;
using DG.Tweening;

public class MenuController : Element
{
    public GameObject ratingPanel;
    public GameObject main;
    public GameObject tapPlaces;

    private void Awake() => app.menu = this;
    private void Start() => SetStart();

    public void SetStart()
    {
        app.model.currentState = MainModel.ChooseState.MainMenu;
        //app.cam.OnMenuMove(tapPlaces);

        if (app.model.onRate == 3 && !PlayerPrefs.HasKey("StopShow"))
        {
            tapPlaces.SetActive(false);
            ratingPanel.SetActive(true);
        } 
        else
            app.cam.OnMenuMove(tapPlaces);
    }

    public void MenuOutTwinner()
    {
        Sequence menuOut = DOTween.Sequence();
        menuOut.Append(main.transform.DOMoveY(10, 1).SetEase(Ease.InBack));
        menuOut.AppendCallback(() => { Instantiate(app.model.runesGame); Destroy(gameObject); });
    }

    public void GoRunes(int index)
    {
        app.model.onRate++;
        tapPlaces.gameObject.SetActive(false);
        app.model.currentState = (MainModel.ChooseState)index;
        MenuOutTwinner();
    }

    public void SetRating()
    {
        PlayerPrefs.SetInt("StopShow", 1);
        PlayerPrefs.Save();
        Application.OpenURL("market://details?id=" + Application.identifier);
        SkipRating();
    }

    public void SkipRating()
    {
        ratingPanel.SetActive(false);
        app.model.onRate = 0;
        app.cam.OnMenuMove(tapPlaces);
    }
}
