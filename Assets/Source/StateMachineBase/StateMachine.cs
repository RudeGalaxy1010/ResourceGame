using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _initialState;

    private State _currentState;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void ResetState()
    {
        _currentState = _initialState;

        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }

    private void Transit(State state)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = state;

        if (_currentState != null)
        {
            _currentState.Enter();
        }
    }
}
