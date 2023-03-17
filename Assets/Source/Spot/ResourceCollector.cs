using UnityEngine;

[RequireComponent(typeof(Spot))]
public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private SpotSettings _spotSettings;

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

        // GetResource
    }
}
