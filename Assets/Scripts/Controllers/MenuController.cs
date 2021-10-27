using UnityEngine;
using DG.Tweening;

public class MenuController : Element
{
    public GameObject main;
    public GameObject tapPlaces;
    public GameObject menu;

    private void Start() => SetStart();

    public void SetStart()
    {
        app.model.currentState = MainModel.ChooseState.MainMenu;
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
        tapPlaces.gameObject.SetActive(false);
        app.model.currentState = (MainModel.ChooseState)index;
        MenuOutTwinner();
    }
}
