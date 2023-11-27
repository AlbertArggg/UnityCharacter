using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup _CinemachineTargetGroup;
    private List<Target> targets = new();
    private SphereCollider TargetingTriggerSphere;
    public float TargetingRadius = 20;
    public Target CurrentTarget { get; private set; }


    private void Start()
    {
        TargetingTriggerSphere = GetComponent<SphereCollider>();
        TargetingTriggerSphere.radius = TargetingRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target t))
        {
            targets.Add(t);
            t.OnDestroyed += RemoveTarget;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Target t))
        {
            RemoveTarget(t);
        }
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0)
            return false;

        CurrentTarget = targets[0];
        _CinemachineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);
        return true;
    }

    public void Cancel()
    {
        if (CurrentTarget == null) return;
        _CinemachineTargetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }

    public void RemoveTarget(Target target)
    {
        if (CurrentTarget == target)
        {
            _CinemachineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }
}