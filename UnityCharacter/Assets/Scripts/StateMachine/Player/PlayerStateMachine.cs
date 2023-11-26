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
        [field: SerializeField] public float _MovementSpeed { get; private set; }
        [field: SerializeField] public float _RotationDamping { get; private set; }

        public Transform _CameraTransform { get; private set; }
        

        private void Start()
        {
            _InputReader = GetComponent<InputReader>();
            _CharacterController = GetComponent<CharacterController>();
            _Animator = GetComponent<Animator>();
            _CameraTransform = Camera.main.transform;
            SwitchState(new PlayerFreeLookState(this));
        }
    }
}