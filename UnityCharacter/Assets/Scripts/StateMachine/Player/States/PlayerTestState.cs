using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerTestState : PlayerBaseState
    {
        private bool _logTick = true;
        
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine){}

        public override void Enter()
        {
            _stateMachine.InputReader.JumpEvent += OnJump;
            Debug.Log("Enter");
        }
        
        public override void Tick(float deltaTime)
        {
            if (_logTick)
            {
                Debug.Log("Tick");
                _logTick = false;
            }
        }

        public override void Exit()
        {
            _stateMachine.InputReader.JumpEvent -= OnJump;
            Debug.Log("Exit");
        }

        private void OnJump()
        {
            _stateMachine.SwitchState(new PlayerTestState(_stateMachine));
        }
    }
}
