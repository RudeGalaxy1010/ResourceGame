using UnityEngine;

public class IsOutOfResource : Transition
{
    [SerializeField] private InProduction _inProductionState;
    [SerializeField] private ProductionSettings _productionSettings;

    private void Update()
    {
        if (_inProductionState.ResourcesProduced >= _productionSettings.MaxResourcesBeforeRecover)
        {
            NeedTransit = true;
        }
    }
}
