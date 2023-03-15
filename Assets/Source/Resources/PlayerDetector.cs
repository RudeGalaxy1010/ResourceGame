using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour
{
    private List<Player> _players;

    public bool IsPlayerInRange => _players.Count > 0;

    private void Awake()
    {
        _players = new List<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _players.Add(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _players.Remove(player);
        }
    }
}
