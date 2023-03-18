using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pointer _resourceProducerPointer;
    [SerializeField] private Pointer _spotPointer;
    [SerializeField] private Spot _spot;

    private void OnEnable()
    {
        _player.Inventory.ResourcesUpdated += OnResourcesUpdated;
        _spot.ProductionStarted += OnProductionStarted;
    }

    private void OnDisable()
    {
        _player.Inventory.ResourcesUpdated -= OnResourcesUpdated;
        _spot.ProductionStarted -= OnProductionStarted;
    }

    private void Start()
    {
        DisablePointers();
        _resourceProducerPointer.enabled = true;
    }

    private void DisablePointers()
    {
        _resourceProducerPointer.enabled = false;
        _spotPointer.enabled = false;
    }

    private void OnResourcesUpdated(Inventory inventory)
    {
        _player.Inventory.ResourcesUpdated -= OnResourcesUpdated;
        _resourceProducerPointer.enabled = false;
        _spotPointer.enabled = true;
    }

    private void OnProductionStarted(Spot spot)
    {
        _spot.ProductionStarted -= OnProductionStarted;
        _spotPointer.enabled = false;
    }
}
