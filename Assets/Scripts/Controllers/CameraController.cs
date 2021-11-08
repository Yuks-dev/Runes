using UnityEngine;
using DG.Tweening;

public class CameraController : Element
{
    public Transform menuView;
    public Transform gameView;
    public Transform runeView;
    public Transform chestView;
    public Transform beginView;
    public Transform quickDivinationView;
    public Transform runeCollectionView;

    private void Awake() => app.cam = this;

    public void GameCameraView() => MovingCam(gameView, 2);         
    public void RuneCameraView() => MovingCam(runeView, 2.5f);

    public void RuneCollectionView(GameObject objectOn)
    {
        app.aux.TransitionSound();

        Sequence move = DOTween.Sequence();
        move.Append(transform.DORotateQuaternion(runeCollectionView.rotation, 2).SetEase(Ease.OutBack));
        move.Join(transform.DOMove(runeCollectionView.position, 2).SetEase(Ease.InBack));
        move.AppendCallback(() => { objectOn.SetActive(true); });
    }

    public void ChestCameraView()
    {
        app.aux.TransitionSound();
        MovingCam(chestView, 2);
    }

    private void MovingCam(Transform targetView, float speed)
    {
        transform.DORotateQuaternion(targetView.rotation, speed).SetEase(Ease.OutBack);
        transform.DOMove(targetView.position, speed).SetEase(Ease.OutCubic);
    }

    public void OnMenuMove(GameObject objectOn)
    {
        Sequence move = DOTween.Sequence();
        move.Append(transform.DORotateQuaternion(menuView.rotation, 2).SetEase(Ease.OutBack));
        move.Join(transform.DOMove(menuView.position, 2).SetEase(Ease.OutCubic));
        move.AppendCallback(() => { objectOn.gameObject.SetActive(true); });
    }

    public void OnQuickMove(GameObject objectOn)
    {
        app.aux.TransitionSound();
        Sequence move = DOTween.Sequence();
        move.Append(transform.DORotateQuaternion(quickDivinationView.rotation, 2).SetEase(Ease.OutBack));
        move.Join(transform.DOMove(quickDivinationView.position, 2).SetEase(Ease.OutCubic));
        move.AppendCallback(() => { objectOn.gameObject.SetActive(true); });
    }
}
