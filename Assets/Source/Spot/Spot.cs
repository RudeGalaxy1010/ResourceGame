using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField] private SpotSettings _spotSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private int _inputResourceQuantity;
    private float _timer;
    private bool _inProduction;

    private void Update()
    {
        Produce();

        if (_inputResourceQuantity >= _spotSettings.InputValue)
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
    }

    private void CreateOutput()
    {
        //List<Resource> resources = _resourcesPool.Get(_spotSettings.OutputResource, _spotSettings.OutputValue);

        //for (int i = 0; i < resources.Count; i++)
        //{
        //    resources[i].transform.position = Random.insideUnitSphere;
        //}
    }
}
