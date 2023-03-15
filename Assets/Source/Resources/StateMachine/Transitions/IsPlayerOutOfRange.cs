using UnityEngine;

public class IsPlayerOutOfRange : Transition
{
    [SerializeField] private PlayerDetector _playerDetector;

    private void Update()
    {
        if (_playerDetector.IsPlayerInRange == false)
        {
            NeedTransit = true;
        }
    }
}
