using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BagView : Element
{
    public GameObject tapButton;
    public Image force;
    public Transform runesParent;

    private int runesFrombag = 0;
    private Vector3 startPos;

    private void Start()
    {
        app.cameraController.ChestCameraView();
        startPos = transform.position;
    }

    private void Update() => force.fillAmount -= 0.2f * Time.deltaTime;

    public void TapChest()
    {
        force.fillAmount += 0.3f;
        ShakingBag(startPos);

        if (force.fillAmount == 1)
            ThrowRunes();

        if (runesFrombag == app.controller.state.RunesCount)
            StartDivination();
    }

    private void ThrowRunes()
    {
        force.fillAmount = 0;
        runesFrombag++;
        SpawnRunes(runesParent);
    }

    private void StartDivination()
    {
        tapButton.SetActive(false);
        app.controller.runeActive = false;

        app.controller.ui.SetState();
        app.controller.ui.ActivatePanels(true);
        app.cameraController.GameCameraView();
        transform.DOMoveY(10, 1).SetEase(Ease.InBack);
        Destroy(gameObject, 2);
    }

    private void SpawnRunes(Transform parent) // Component
    {
        float rnd_x = Random.Range(-3, 3);
        float rnd_z = Random.Range(-0.5f, 1);
        Instantiate(app.model.runePrefab, new Vector3(rnd_x, 3, rnd_z), Quaternion.identity, parent);
    }

    private void ShakingBag(Vector3 position) // Component
    {
        transform.DOJump(position, 0.5f, 1, 0.2f);
        Sequence bagShuffle = DOTween.Sequence();
        bagShuffle.Append(transform.DOScale(2.2f, 0.2f));
        bagShuffle.Append(transform.DOScale(2, 0.2f));
    }
}
