using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private ScaleAnimationSettings _scaleAnimationSettings;

    private Tween _tween;
    private float _scaleEndValue;
    private float _duration;

    private void Start()
    {
        _scaleEndValue = transform.localScale.x * _scaleAnimationSettings.ScaleEndValue;
        _duration = _scaleAnimationSettings.Duration / 2f; // Scale up and return to default takes double time
    }

    public void PlayOnce()
    {
        Play(2);
    }

    public void PlayInfinite()
    {
        Play(-1);
    }

    public void Stop()
    {
        _tween.Kill();
    }

    private void Play(int loops)
    {
        _tween = transform.DOScale(_scaleEndValue, _duration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
