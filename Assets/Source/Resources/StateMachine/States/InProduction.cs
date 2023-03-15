using UnityEngine;

public class InProduction : State
{
    [SerializeField] private Resource _resource;
    [SerializeField] private ProductionSettings _productionSettings;
    [SerializeField] private Transform _spawnPoint;

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
            Instantiate(_resource.Prefab, _spawnPoint.position, Quaternion.identity);
            _resourcesProduced++;
            _timer = 0;
        }
    }
}
