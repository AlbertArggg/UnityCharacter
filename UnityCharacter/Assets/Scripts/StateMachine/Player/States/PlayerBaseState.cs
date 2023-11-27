using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine _stateMachine;

        protected PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        protected void Move(Vector3 motion, float deltaTime)
        {
            _stateMachine._CharacterController.Move((motion + _stateMachine._ForceReceiver.Movement) * deltaTime);
        }
        
        protected void FaceTarget()
        {
            if (_stateMachine._Targeter.CurrentTarget != null)
            {
                Vector3 faceDirection =
                    _stateMachine._Targeter.CurrentTarget.transform.position - _stateMachine.transform.position;

                faceDirection.y = 0;
                _stateMachine.transform.rotation = Quaternion.LookRotation(faceDirection);
            }
        }
    }
}
