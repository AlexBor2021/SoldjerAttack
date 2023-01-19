using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   [SerializeField] private State _currentState;

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();

        if (nextState != null)
        {
            _currentState.gameObject.SetActive(false);
            nextState.gameObject.SetActive(true);

            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        _currentState = nextState;
    }
}
