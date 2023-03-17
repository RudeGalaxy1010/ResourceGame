using DG.Tweening;
using TMPro;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    private const float ScaleEndValue = 1.1f;
    private const float ScaleDuration = 0.5f;

    [SerializeField] private TMP_Text _quantityText;

    private int _currentQuantity;
    private Sequence _tween;

    public void SetQuantity(int quantity)
    {
        if (_currentQuantity < quantity)
        {
            PlayScaleAnimation();
        }

        _currentQuantity = quantity;
        _quantityText.text = quantity.ToString();
    }

    private void PlayScaleAnimation()
    {
        if (_tween != null)
        {
            return;
        }

        _tween = DOTween.Sequence()
            .Append(transform.DOScale(ScaleEndValue, ScaleDuration / 2f).SetLoops(2, LoopType.Yoyo))
            .AppendCallback(() => _tween = null);
    }
}
