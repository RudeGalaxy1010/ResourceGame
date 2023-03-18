using UnityEngine;

public class Recover : State
{
    [SerializeField] private ProductionSettings _productionSettings;

    private float _timer = 0;

    public bool RecoverFinished { get; private set; }

    private void OnEnable()
    {
        RecoverFinished = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _productionSettings.RecoverTime)
        {
            _timer = 0;
            RecoverFinished = true;
        }
    }
}
