using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private DetectionSettings _detectionSettings;

    private List<Player> _players = new List<Player>();

    public bool IsPlayerInRange => _players.Count > 0;
    public IReadOnlyList<Player> Players => _players;

    private void Awake()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.radius = _detectionSettings.DetectionRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && _players.Contains(player) == false)
        {
            _players.Add(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player) && _players.Contains(player) == true)
        {
            _players.Remove(player);
        }
    }
}
