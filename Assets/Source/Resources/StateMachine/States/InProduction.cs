using System;
using UnityEngine;

public class InProduction : State
{
    public event Action<InProduction> ProductionStarted;

    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private ProductionSettings _productionSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private float _timer;
    private int _resourcesProduced;

    public int ResourcesProduced => _resourcesProduced;

    private void OnEnable()
    {
        _timer = 0;
        _resourcesProduced = 0;
        ProductionStarted?.Invoke(this);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _productionSettings.TimeToGetResourceUnit)
        {
            _resourceSpawner.SpawnResource(_resourceType);
            _resourcesProduced++;
            _timer = 0;
        }
    }
}
