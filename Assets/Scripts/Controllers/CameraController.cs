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

    private void Awake()
    {
        app.cameraController = this;
        transform.position = beginView.position;
        transform.rotation = beginView.rotation;
    }

    public void MenuCameraView() => MovingCam(menuView, 3);
    public void GameCameraView() => MovingCam(gameView, 2);  
    public void RuneCameraView() => MovingCam(runeView, 2.5f);
    public void ChestCameraView() => MovingCam(chestView, 2);
    public void QuickCameraView() => MovingCam(quickDivinationView, 1);

    private void MovingCam(Transform targetView, float speed)
    {
        transform.DORotateQuaternion(targetView.rotation, speed).SetEase(Ease.OutBack);
        transform.DOMove(targetView.position, speed).SetEase(Ease.OutCubic);
    }
}
