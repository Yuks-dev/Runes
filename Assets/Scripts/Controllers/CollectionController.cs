using UnityEngine;

public class CollectionController : Element
{
    public MenuController menu;
    public RectTransform collectionPanel;

    public void BackToMenu() => menu.SetStart();
    public void Rewarded() => app.ad.ShowRewardedAD();

    public void LaunchCollection()
    {
        app.cam.RuneCollectionView(collectionPanel.gameObject);
        menu.tapPlaces.gameObject.SetActive(false);
        app.ad.RequestRewarded();
    }
}
