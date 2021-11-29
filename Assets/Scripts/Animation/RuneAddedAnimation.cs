using UnityEngine;
using DG.Tweening;

public class RuneAddedAnimation : Element
{
    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(0, 0);

        Sequence anim = DOTween.Sequence();
        anim.Append(gameObject.transform.DOScale(new Vector3(1, 1), 0.3f).SetEase(Ease.OutBack));
        anim.AppendInterval(1);
        anim.Append(gameObject.transform.DOScale(new Vector3(0, 0), 0.3f).SetEase(Ease.InBack));
        anim.AppendCallback(() => gameObject.SetActive(false));
    }

}
