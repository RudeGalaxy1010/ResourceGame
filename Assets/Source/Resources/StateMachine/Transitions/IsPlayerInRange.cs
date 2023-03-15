using UnityEngine;

public class IsPlayerInRange : Transition
{
    [SerializeField] private PlayerDetector _playerDetector;

    private void Update()
    {
        if (_playerDetector.IsPlayerInRange == true)
        {
            NeedTransit = true;
        }
    }
}
