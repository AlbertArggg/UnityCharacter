using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        private const float ANIMATOR_DAMP_TIME = 0.1f;

        private readonly int FreeLookMovementSpeed = 
            Animator.StringToHash(Constants.AnimationStrings.FREELOOK_MOVEMENT_SPEED);

        public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine){}

        public override void Enter()
        {
            
        }
        
        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();
            _stateMachine._CharacterController.Move(movement * (_stateMachine._MovementSpeed * deltaTime));

            if (_stateMachine._InputReader.MovementValue == Vector2.zero)
            {
                _stateMachine._Animator.SetFloat(FreeLookMovementSpeed, 0, ANIMATOR_DAMP_TIME, deltaTime);
                return;
            }

            _stateMachine._Animator.SetFloat(FreeLookMovementSpeed, 1, ANIMATOR_DAMP_TIME, deltaTime);
            FaceMovementDirection(movement, deltaTime);
        }

        private Vector3 CalculateMovement()
        {
            Vector3 forward = _stateMachine._CameraTransform.forward;
            Vector3 right = _stateMachine._CameraTransform.right;
            
            forward.y = right.y = 0;
            
            forward.Normalize(); right.Normalize();

            return forward * _stateMachine._InputReader.MovementValue.y +
                   right * _stateMachine._InputReader.MovementValue.x;
        }
        
        private void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            _stateMachine.transform.rotation = 
                Quaternion.Lerp(_stateMachine.transform.rotation, Quaternion.LookRotation(movement), _stateMachine._RotationDamping);
        }

        public override void Exit()
        {
            
        }
    }
}
