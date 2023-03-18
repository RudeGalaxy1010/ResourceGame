using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spot))]
public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private SpotSettings _spotSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private void Update()
    {
        if (_playerDetector.IsPlayerInRange == false)
        {
            return;
        }

        for (int i = 0; i < _playerDetector.Players.Count; i++)
        {
            TryGetResource(_playerDetector.Players[i]);
        }
    }

    private void TryGetResource(Player player)
    {
        if (player.Move.IsMoving == true
            || player.Inventory.HasResource(_spotSettings.InputResource) == false)
        {
            return;
        }

        int resourceInInventoryQuantity = player.Inventory.GetResourceQuantity(_spotSettings.InputResource);
        int quantityToRemove = resourceInInventoryQuantity >= _spotSettings.InputValue
            ? _spotSettings.InputValue : resourceInInventoryQuantity;
        player.Inventory.RemoveResource(_spotSettings.InputResource, quantityToRemove);

        StartCoroutine(StartResourceSpawn(quantityToRemove, player));
    }

    private IEnumerator StartResourceSpawn(int quantity, Player player)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.25f);

        for (int i = 0; i < quantity; i++)
        {
            Resource resource = _resourceSpawner.SpawnResource(_spotSettings.InputResource);
            PickUp pickUp = resource.GetComponent<PickUp>();
            pickUp.SetActive(false);
            Vector3 offset = new Vector3(Random.value, Random.value, 0) * 2f;
            pickUp.transform.position = player.transform.position + offset;
            pickUp.StartMoveTo(transform);
            yield return waitForSeconds;
        }
    }
}
