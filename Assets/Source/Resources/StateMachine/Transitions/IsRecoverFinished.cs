using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRecoverFinished : Transition
{
    [SerializeField] private ProductionSettings _productionSettings;

    private float _timer;

    private void OnEnable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _productionSettings.RecoverTime)
        {
            NeedTransit = true;
        }
    }
}
