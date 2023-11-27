using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerTargetingState : PlayerBaseState
    {
        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine){}
        
        private readonly int TargetedBlendTree = 
            Animator.StringToHash(Constants.AnimationStrings.TARGETED_BLEND_TREE);
        
        private readonly int TargetedMovementSpeedForward = 
            Animator.StringToHash(Constants.AnimationStrings.TARGETED_MOVEMENT_SPEED_FORWARD);
        
        private readonly int TargetedMovementSpeedRight = 
            Animator.StringToHash(Constants.AnimationStrings.TARGETED_MOVEMENT_SPEED_RIGHT);
        
        public override void Enter()
        {
            _stateMachine._InputReader.CancelEvent += OnCancel;
            _stateMachine._Animator.Play(TargetedBlendTree);
        }
        
        public override void Tick(float deltaTime)
        {
            if (_stateMachine._Targeter.CurrentTarget == null)
            {
                _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
                return;
            }

            Vector3 movement = CalculateMovement();
            Move(movement*_stateMachine._TargetingMovementSpeed, deltaTime);

            UpdateAnimator(deltaTime);
            
            FaceTarget();
        }

        public override void Exit()
        {
            _stateMachine._InputReader.CancelEvent -= OnCancel;
        }

        private void OnCancel()
        {
            _stateMachine._Targeter.Cancel();
            _stateMachine.SwitchState(new PlayerFreeLookState(_stateMachine));
        }

        private Vector3 CalculateMovement()
        {
            Vector3 movement = new Vector3();

            movement += _stateMachine.transform.right * _stateMachine._InputReader.MovementValue.x;
            movement += _stateMachine.transform.forward * _stateMachine._InputReader.MovementValue.y;
            
            return movement;
        }

        private void UpdateAnimator(float deltaTime)
        {
            if (_stateMachine._InputReader.MovementValue.y == 0)
            {
                _stateMachine._Animator.SetFloat(TargetedMovementSpeedForward, 0, 0.1f, deltaTime);
            }
            else
            {
                float value = _stateMachine._InputReader.MovementValue.y > 0 ? 1f : -1f;
                _stateMachine._Animator.SetFloat(TargetedMovementSpeedForward,value, 0.1f, deltaTime);
            }
            
            if (_stateMachine._InputReader.MovementValue.x == 0)
            {
                _stateMachine._Animator.SetFloat(TargetedMovementSpeedRight, 0, 0.1f, deltaTime);
            }
            else
            {
                float value = _stateMachine._InputReader.MovementValue.x > 0 ? 1f : -1f;
                _stateMachine._Animator.SetFloat(TargetedMovementSpeedRight,value, 0.1f, deltaTime);
            }
        }
    }
}