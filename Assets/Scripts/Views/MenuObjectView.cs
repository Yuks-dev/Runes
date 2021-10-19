using UnityEngine;

public class MenuObjectView : Element
{
    public GameObject menu;
    public enum MenuState { Runes4, Runes7, Runes13, MainMenu }
    public MenuState menuState;

    private MenuController menuController;

    private void Start()
    {
        menuController = menu.GetComponent<MenuController>();
    }

    private void OnMouseDown()
    {
        app.model.currentState = (MainModel.ChooseState)menuState;
        menuController.SetInactive();
        menuController.MenuOutTwinner();
    }
}
