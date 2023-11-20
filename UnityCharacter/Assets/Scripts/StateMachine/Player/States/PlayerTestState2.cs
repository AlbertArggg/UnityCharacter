using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerTestState2 : PlayerBaseState
    {
        private bool _logTick = true;
        
        public PlayerTestState2(PlayerStateMachine stateMachine) : base(stateMachine){}

        public override void Enter()
        {
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
            Debug.Log("Exit");
        }
    }
}
