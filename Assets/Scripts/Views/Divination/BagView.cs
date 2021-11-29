using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BagView : Element
{
    public Image progress;
    public Transform runesParent;
    public GameObject tapButton;

    private int runesFrombag = 0;
    private Vector3 startPos;

    private void Start()
    {
        app.cam.ChestCameraView();
        startPos = transform.position;
    }

    private void Update() => progress.fillAmount -= 0.1f * Time.deltaTime;

    public void TapChest()
    {
        app.controller.canTake = false;
        app.aux.ChestSound();
        progress.fillAmount += 0.2f;
        ShakingBag(startPos);

        if (progress.fillAmount == 1)
        {
            runesFrombag++;

            Sequence progScale = DOTween.Sequence();
            progScale.Append(progress.transform.DOScale(new Vector3(1.05f, 1.2f, 0), 0.1f));
            progScale.Join(progress.DOColor(Color.green, 0.1f));
            progScale.Append(progress.transform.DOScale(new Vector3(1f, 1f, 0), 0.1f));
            progScale.Join(progress.DOColor(Color.white, 0.1f));

            SpawnRunes(runesParent);
        }

        if (runesFrombag == app.controller.state.RunesCount)
        {
            tapButton.gameObject.SetActive(false);
            progress.gameObject.SetActive(false);
            StartDivination();
        }  
    }

    private void StartDivination()
    {
        app.controller.ui.SetState();
        app.cam.GameCameraView();

        transform.DOMoveY(10, 1).SetEase(Ease.InBack).OnComplete(() => {
            app.controller.canTake = true;
            Destroy(gameObject);
        });
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
