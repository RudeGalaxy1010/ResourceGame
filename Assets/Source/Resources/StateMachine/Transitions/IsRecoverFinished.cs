using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsRecoverFinished : Transition
{
    [SerializeField] private Recover _recover;

    private void Update()
    {
        if (_recover.RecoverFinished)
        {
            NeedTransit = true;
        }
    }
}
