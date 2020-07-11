﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    private NavMeshAgent _navMashAgent;
    private Transform _target;
    private float _updateTime = 0.5f;
    protected override void Start()
    {
        base.Start();
        _navMashAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        
        StartCoroutine(RefreshTargetPos());
    }

    private IEnumerator RefreshTargetPos()
    {
        while(_target != null)
        {
            _navMashAgent.SetDestination(_target.position);
            yield return new WaitForSeconds(_updateTime);
        }
    }

    public override void Die()
    {
        base.Die();
        //ping enemy-spawner to update the spawn
        gameObject.SetActive(false);
    }
}
