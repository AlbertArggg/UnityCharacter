using System;
using System.Collections;
using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerStateMachine : StateMachine
    {
        private void Start()
        {
            SwitchState(new PlayerTestState(this));
            StartCoroutine(WaitAndSwitchStates());
        }

        IEnumerator WaitAndSwitchStates()
        {
            yield return new WaitForSeconds(4);
            SwitchState(new PlayerTestState2(this));
        }
    }
}