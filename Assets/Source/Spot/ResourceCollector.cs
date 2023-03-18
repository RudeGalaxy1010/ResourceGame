using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spot))]
public class ResourceCollector : MonoBehaviour
{
    private const float ValueOffset = 0.5f;

    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private SpotSettings _spotSettings;
    [SerializeField] private CollectionSettings _collectionSettings;
    [SerializeField] private ResourceSpawner _resourceSpawner;

    private Coroutine _collectionCoroutine;

    private void Update()
    {
        if (_playerDetector.IsPlayerInRange == false)
        {
            if (_collectionCoroutine != null)
            {
                StopCoroutine(_collectionCoroutine);
                _collectionCoroutine = null;
            }

            return;
        }

        for (int i = 0; i < _playerDetector.Players.Count; i++)
        {
            TryGetResource(_playerDetector.Players[i]);
        }
    }

    private void TryGetResource(Player player)
    {
        if (_collectionCoroutine != null)
        {
            return;
        }

        if (player.Move.IsMoving == true
            || player.Inventory.HasResource(_spotSettings.InputResource) == false)
        {
            return;
        }

        _collectionCoroutine = StartCoroutine(StartResourceSpawn(player));
    }

    private IEnumerator StartResourceSpawn(Player player)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_collectionSettings.SpawnDelay);

        while (player.Inventory.HasResource(_spotSettings.InputResource))
        {
            player.Inventory.RemoveResource(_spotSettings.InputResource, 1);
            Resource resource = _resourceSpawner.SpawnResource(_spotSettings.InputResource);
            PickUp pickUp = resource.GetComponent<PickUp>();
            pickUp.SetActive(false);
            Vector3 offset = new Vector3(Random.value - ValueOffset, Random.value - ValueOffset, 0)
                * _collectionSettings.Spread;
            pickUp.transform.position = player.transform.position + offset;
            pickUp.StartMoveTo(transform);
            yield return waitForSeconds;
        }

        _collectionCoroutine = null;
    }
}
