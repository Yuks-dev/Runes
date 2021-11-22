using UnityEngine;

public class CollectionController : Element
{
    public MenuController menu;
    public RectTransform collectionPanel;
    public GameObject rewardButton;

    public void BackToMenu() => menu.SetStart();
    public void Rewarded() => app.ad.ShowRewardedAD();

    private void Update()
    {
        if (app.ad.rewardedLoad)
            rewardButton.SetActive(true);
        else
            rewardButton.SetActive(false);
    }

    public void LaunchCollection()
    {
        app.cam.RuneCollectionView(collectionPanel.gameObject);
        menu.tapPlaces.gameObject.SetActive(false);
        app.ad.RequestRewarded();
    }
}
