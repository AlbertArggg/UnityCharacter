using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    private float _verticalVelocity;

    public Vector3 Movement => Vector3.up * _verticalVelocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_verticalVelocity<0f && _characterController.isGrounded)
        {
            _verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
