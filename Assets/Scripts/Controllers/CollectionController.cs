using UnityEngine;

public class CollectionController : Element
{
    public MenuController menu;
    public RectTransform collectionPanel;

    public void BackToMenu() => menu.SetStart();
}
