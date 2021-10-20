using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BagView : Element
{
    public GameObject tapButton;
    public Image force;
    public Transform runesParent;

    private bool onClick = true;
    private int runesFrombag = 0;
    private Vector3 startPos;

    private void Start()
    {
        app.cameraController.ChestCameraView();
        startPos = transform.position;
    }

    private void Update()
    {
        if(onClick)
            force.fillAmount -= 0.2f * Time.deltaTime;
    }

    public void TapChest()
    {
        force.fillAmount += 0.1f;
        ShakingBag(startPos);

        if (force.fillAmount == 1)
        {
            runesFrombag++;
            ForceAnimation();
            SpawnRunes(runesParent);
        }

        if (runesFrombag == app.controller.state.RunesCount)
            StartDivination();
    }

    private void ForceAnimation()
    {
        Sequence complete = DOTween.Sequence();
        complete.PrependCallback(() => { force.fillAmount = 1; tapButton.SetActive(false); onClick = false; });
        complete.Append(force.gameObject.transform.DOScale(1.02f, 0.2f).SetEase(Ease.OutBack));
        complete.Join(force.DOColor(Color.green,0.2f));
        complete.Append(force.gameObject.transform.DOScale(1, 0.2f));
        complete.Join(force.DOColor(Color.white, 0.2f));
        complete.AppendCallback(() => { tapButton.SetActive(true); onClick = true; });
    }

    private void StartDivination()
    {
        tapButton.SetActive(false);
        force.gameObject.SetActive(false);

        app.controller.runeActive = false;
        app.controller.ui.SetState();
        app.cameraController.GameCameraView();

        transform.DOMoveY(10, 1).SetEase(Ease.InBack);
        Destroy(gameObject, 1.5f);
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
