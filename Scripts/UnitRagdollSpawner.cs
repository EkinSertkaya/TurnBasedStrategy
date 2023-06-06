using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRagdollSpawner : MonoBehaviour
{
    [SerializeField] private Transform ragdollPreFab;
    [SerializeField] private Transform originalRootBone;

    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();

        healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        Transform ragDollTransform = Instantiate(ragdollPreFab, transform.position, transform.rotation);
        UnitRagdoll unitRagDoll = ragDollTransform.GetComponent<UnitRagdoll>();
        unitRagDoll.Setup(originalRootBone);
    }
}
