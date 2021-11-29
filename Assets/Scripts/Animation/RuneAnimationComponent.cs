using DG.Tweening;
using UnityEngine;

public class RuneAnimationComponent : Element
{
    public GameObject shining;
    public GameObject magicSmoke;
    public GameObject blow;
    public GameObject blowSign;

    private Sequence showRune;

    public void RuneAnimation(GameObject runeSign)
    {
        Spawner(magicSmoke);
        showRune = DOTween.Sequence();
        showRune.PrependInterval(0.5f);

        // Goes up
        showRune.Append(transform.DOMove(new Vector3(0, 4, -1), 1).SetEase(Ease.OutBounce));
        showRune.AppendCallback(() => { app.cam.RuneCameraView(); });

        // Rotate
        showRune.Join(transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic));
        showRune.AppendCallback(() => {
            Spawner(runeSign);
            Spawner(shining);
            Spawner(blowSign);
            app.controller.ui.SetDescription();
            app.aux.RotateSound();
        });
        showRune.AppendInterval(5);

        // Fly away
        showRune.AppendCallback(() => {
            app.controller.ui.StopDescription();
            app.cam.GameCameraView();
            app.controller.ui.SetState();
            
        });
        showRune.Append(transform.DOMove(new Vector3(3, 8, -7), 2));
        showRune.AppendCallback(() => {
            Destroy(gameObject);
            app.controller.canTake = true;
            app.controller.runeLaunch = false;
        });
    }

    private void Spawner(GameObject obj)
    {
        Instantiate(obj, transform.position, obj.transform.rotation, gameObject.transform);
    }

    private void OnDestroy() => showRune.Kill();

}
