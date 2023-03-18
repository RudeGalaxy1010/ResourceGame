using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour
{
    private List<Player> _players;

    public bool IsPlayerInRange => _players.Count > 0;
    public IReadOnlyList<Player> Players => _players;

    private void OnEnable()
    {
        _players = new List<Player>();
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
