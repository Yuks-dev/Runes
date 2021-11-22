using DG.Tweening;
using UnityEngine;

public class RuneAnimationComponent : Element
{
    public GameObject shining;
    public GameObject magicSmoke;
    public GameObject blow;
    public GameObject blowSign;

    private Sequence punchRune;

    public void RuneTaken(GameObject rune)
    {
        punchRune = DOTween.Sequence();
        punchRune.Append(rune.transform.DOScale(1.2f, 0.2f));
        punchRune.Append(rune.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack));
        punchRune.SetLoops(3);
    }

    public void StopRuneTaken() => punchRune.Kill();


    public void RuneAnimation(GameObject runeSign)
    {
        Spawner(magicSmoke);
        Sequence showRune = DOTween.Sequence();
        showRune.PrependInterval(0.5f);

        // Goes up
        showRune.Append(transform.DOMove(new Vector3(0, 4, -1), 1).SetEase(Ease.OutBounce));
        showRune.AppendCallback(() => { app.cam.RuneCameraView(); });

        // Rotate
        showRune.Join(transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() =>
        {
            Spawner(runeSign);
            Spawner(shining);
            Spawner(blowSign);

            app.controller.ui.runeAddPanel.gameObject.SetActive(true);
            app.controller.ui.ShowDescription();
            app.controller.ui.runeName.gameObject.SetActive(true);
            app.aux.RotateSound();
        });
        showRune.AppendInterval(5);

        // Fly away
        showRune.AppendCallback(() =>
        {
            app.controller.ui.runeName.gameObject.SetActive(false);
            app.controller.ui.HideDescription();
            app.cam.GameCameraView();
        });
        showRune.Append(transform.DOMove(new Vector3(3, 8, -7), 2));
        showRune.AppendCallback(() =>
        {
            app.controller.ui.SetState();
            app.controller.runeActive = false;
            Destroy(gameObject);
        });
    }

    private void Spawner(GameObject obj)
    {
        Instantiate(obj, transform.position, obj.transform.rotation, gameObject.transform);
    }
}
