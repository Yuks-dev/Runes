using UnityEngine;
using DG.Tweening;

public class MenuController : Element
{
    public GameObject main;
    public GameObject runes4;
    public GameObject runes7;
    public GameObject runes13;

    private void Start()
    {
        app.model.currentState = MainModel.ChooseState.MainMenu;
        app.cameraController.MenuCameraView();
    }

    public void SetInactive()
    {
        runes4.GetComponent<BoxCollider>().enabled = false;
        runes7.GetComponent<BoxCollider>().enabled = false;
        runes13.GetComponent<BoxCollider>().enabled = false;
    }

    public void MenuOutTwinner()
    {
        Sequence menuOut = DOTween.Sequence();
        menuOut.Append(main.transform.DOMoveY(10, 1).SetEase(Ease.InBack));
        menuOut.AppendCallback(() => { Instantiate(app.model.runesGame); Destroy(gameObject); });
    }
}
