using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Pointer _resourceProducerPointer;
    [SerializeField] private InProduction _inProductionState;
    [SerializeField] private Pointer _spotPointer;
    [SerializeField] private Spot _spot;
    [SerializeField] private GameObject _pointerIcon;

    private void OnEnable()
    {
        _inProductionState.ProductionStarted += OnResourceProductionStarted;
        _spot.ProductionStarted += OnSpotProductionStarted;
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

    private void OnResourceProductionStarted(InProduction inProduction)
    {
        inProduction.ProductionStarted -= OnResourceProductionStarted;
        _resourceProducerPointer.enabled = false;
        _spotPointer.enabled = true;
    }

    private void OnSpotProductionStarted(Spot spot)
    {
        _spot.ProductionStarted -= OnSpotProductionStarted;
        _spotPointer.enabled = false;
        _pointerIcon.SetActive(false);
    }
}
