using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ResourceItem _woodItem;
    [SerializeField] private ResourceItem _metalItem;
    [SerializeField] private ResourceItem _crystalItem;

    private void OnEnable()
    {
        _player.Inventory.ResourcesUpdated += OnResourcesUpdated;
    }

    private void OnDisable()
    {
        _player.Inventory.ResourcesUpdated -= OnResourcesUpdated;
    }

    private void Start()
    {
        UpdateResources(_player.Inventory);
    }

    private void OnResourcesUpdated(Inventory inventory)
    {
        UpdateResources(inventory);
    }

    private void UpdateResources(Inventory inventory)
    {
        _woodItem.gameObject.SetActive(inventory.HasResource(ResourceType.Wood));
        _metalItem.gameObject.SetActive(inventory.HasResource(ResourceType.Metal));
        _crystalItem.gameObject.SetActive(inventory.HasResource(ResourceType.Crystal));

        _woodItem.SetQuantity(inventory.GetResourceQuantity(ResourceType.Wood));
        _metalItem.SetQuantity(inventory.GetResourceQuantity(ResourceType.Metal));
        _crystalItem.SetQuantity(inventory.GetResourceQuantity(ResourceType.Crystal));
    }
}
