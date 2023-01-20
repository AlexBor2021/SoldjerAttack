using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   [SerializeField] private State _currentState;

    private void FixedUpdate()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        _currentState = nextState;
    }
}
