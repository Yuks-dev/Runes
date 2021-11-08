using DG.Tweening;
using UnityEngine;

public class SignView : Element
{
    private void Start() => transform.DOLocalMoveY(-0.75f, 0.5f);
    private void Update() => transform.Rotate(Vector3.up, 100 * Time.deltaTime);
}
