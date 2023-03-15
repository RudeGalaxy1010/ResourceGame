using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private bool _entered;

    public void Enter()
    {
        if (_entered == true)
        {
            return;
        }

        enabled = true;
        _entered = true;

        for (int i = 0; i < _transitions.Count; i++)
        {
            _transitions[i].enabled = true;
        }
    }

    public void Exit()
    {
        if (_entered == false)
        {
            return;
        }

        for (int i = 0; i < _transitions.Count; i++)
        {
            _transitions[i].enabled = false;
        }

        enabled = false;
        _entered = false;
    }

    public State GetNextState()
    {
        for (int i = 0; i < _transitions.Count; i++)
        {
            if (_transitions[i].NeedTransit)
            {
                return _transitions[i].TargetState;
            }
        }

        return null;
    }
}
