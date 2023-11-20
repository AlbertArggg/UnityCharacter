namespace Scripts.StateMachine.Player
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine _stateMachine;

        protected PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}
