using System;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public event Action<Spot> ProductionStarted;

    [SerializeField] private SpotSettings _spotSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;
    [SerializeField] private ScaleAnimation _scaleAnimation;

    private int _inputResourceQuantity;
    private float _timer;
    private bool _inProduction;

    private void Update()
    {
        Produce();

        if (_inputResourceQuantity >= _spotSettings.InputValue && _inProduction == false)
        {
            StartProduction();
        }
    }

    public void AddResource(int quantity)
    {
        _inputResourceQuantity += quantity;
    }

    private void Produce()
    {
        if (_inProduction == false)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _spotSettings.ProductionDuration)
        {
            CreateOutput();
            _timer = 0;
            _inProduction = false;
        }
    }

    private void StartProduction()
    {
        _inputResourceQuantity -= _spotSettings.InputValue;
        _inProduction = true;
        ProductionStarted?.Invoke(this);
        _scaleAnimation.PlayInfinite();
    }

    private void CreateOutput()
    {
        _scaleAnimation.Stop();
        for (int i = 0; i < _spotSettings.OutputValue; i++)
        {
            _resourceSpawner.SpawnResource(_spotSettings.OutputResource);
        }
    }
}
