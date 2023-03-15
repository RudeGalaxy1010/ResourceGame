using UnityEngine;

public class InProduction : State
{
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private ProductionSettings _productionSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private float _timer;
    private int _resourcesProduced;

    public int ResourcesProduced => _resourcesProduced;

    private void OnEnable()
    {
        _timer = 0;
        _resourcesProduced = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _productionSettings.TimeToGetResourceUnit)
        {
            _resourceSpawner.SpawnResource(_resourcePrefab);
            _resourcesProduced++;
            _timer = 0;
        }
    }
}
