using System;
using System.Collections;
using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field:SerializeField] public InputReader _InputReader { get; private set; }
        [field: SerializeField] public CharacterController _CharacterController { get; private set; }
        [field: SerializeField] public Animator _Animator { get; private set; }
        [field: SerializeField] public Targeter _Targeter { get; private set; }
        [field: SerializeField] public ForceReceiver _ForceReceiver { get; private set; }

        public Transform _CameraTransform { get; private set; }
        
        [field: SerializeField] public float _MovementSpeed { get; private set; }
        [field: SerializeField] public float _TargetingMovementSpeed { get; private set; }
        [field: SerializeField] public float _RotationDamping { get; private set; }

        private void Start()
        {
            _InputReader = GetComponent<InputReader>();
            _CharacterController = GetComponent<CharacterController>();
            _Animator = GetComponent<Animator>();
            _Targeter = GetComponentInChildren<Targeter>();
            _ForceReceiver = GetComponent<ForceReceiver>();
            if (Camera.main != null) _CameraTransform = Camera.main.transform;
            SwitchState(new PlayerFreeLookState(this));
        }
    }
}